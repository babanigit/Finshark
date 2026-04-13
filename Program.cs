using Finshark.Data;
using Finshark.Interfaces;
using Finshark.Models;
using Finshark.Repositories;
using Finshark.Repository;
using Finshark.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// ── Environment ────────────────────────────────────────────────────────────────
DotNetEnv.Env.Load();
builder.Configuration.AddEnvironmentVariables();

var connStr       = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
                    ?? builder.Configuration.GetConnectionString("DefaultConnection");

var jwtAudience   = Environment.GetEnvironmentVariable("JWT__Audience")
                    ?? builder.Configuration["JWT:Audience"];

var jwtIssuer     = Environment.GetEnvironmentVariable("JWT__Issuer")
                    ?? builder.Configuration["JWT:Issuer"];

var jwtSigningKey = Environment.GetEnvironmentVariable("JWT__SigningKey")
                    ?? builder.Configuration["JWT:SigningKey"];

Console.WriteLine($"✅ connStr={connStr} | jwtAudience={jwtAudience} | jwtIssuer={jwtIssuer}");

// ── Services ───────────────────────────────────────────────────────────────────
builder.Services.AddControllers()
    .AddNewtonsoftJson(o =>
        o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddRazorPages();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connStr)
           .EnableSensitiveDataLogging()
           .LogTo(Console.WriteLine, LogLevel.Information));

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit           = true;
    options.Password.RequireLowercase       = true;
    options.Password.RequireUppercase       = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength         = 12;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme    =
    options.DefaultForbidScheme       =
    options.DefaultScheme             =
    options.DefaultSignInScheme       =
    options.DefaultSignOutScheme      = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer           = true,
        ValidIssuer              = jwtIssuer,
        ValidateAudience         = true,
        ValidAudience            = jwtAudience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey         = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(jwtSigningKey!))
    };
});

// Dependency injection
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<IStockRepository,     StockRepository>();
builder.Services.AddScoped<ICommentRepository,   CommentRepository>();
builder.Services.AddScoped<ITokenService,        TokenService>();
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<IFMPService,          FMPService>();
builder.Services.AddHttpClient<IFMPService,      FMPService>();

// ── Build ──────────────────────────────────────────────────────────────────────
var app = builder.Build();

// ── Auto-migrate ───────────────────────────────────────────────────────────────
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

// ── React static files ─────────────────────────────────────────────────────────
var reactPath = Path.Combine(Directory.GetCurrentDirectory(), "frontend", "dist");
var reactExists = Directory.Exists(reactPath);

Console.WriteLine(reactExists
    ? $"✅ React dist found at: {reactPath}"
    : $"⚠️  React dist NOT found at: {reactPath} — serving API only");

if (reactExists)
{
    app.UseDefaultFiles(new DefaultFilesOptions
    {
        FileProvider = new PhysicalFileProvider(reactPath),
        RequestPath  = ""
    });

    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(reactPath),
        RequestPath  = ""
    });
}

// ── Middleware pipeline ────────────────────────────────────────────────────────
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAll");       // must come after UseRouting
app.UseAuthentication();
app.UseAuthorization();

// ── Endpoints ──────────────────────────────────────────────────────────────────
app.MapRazorPages();
app.MapControllers();

app.MapGet("/api/status", () => Results.Json(new { message = "API is live" }));

// SPA fallback — must be last, only when dist exists
if (reactExists)
{
    app.MapFallbackToFile("index.html", new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(reactPath)
    });
}

app.Run();