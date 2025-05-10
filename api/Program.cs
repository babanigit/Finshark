using api.Data;
using api.Interfaces;
using api.Models;
using api.Repositories;
using api.Repository;
using api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
// using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


// Load .env variables
DotNetEnv.Env.Load();
builder.Configuration.AddEnvironmentVariables();

var config = builder.Configuration;

// // Read config values
// var IS_LOCALHOST = Environment.GetEnvironmentVariable("IS_LOCALHOST");
// var connStr = IS_LOCALHOST == "true"
//     ? Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection_LocalHost")
//     : Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection");

// var fmpKey = Environment.GetEnvironmentVariable("FMPKey");
// var jwtIssuer = Environment.GetEnvironmentVariable("JWT__Issuer");
// var jwtAudience = Environment.GetEnvironmentVariable("JWT__Audience");
// var jwtSigningKey = Environment.GetEnvironmentVariable("JWT__SigningKey");

// // Debug output
// Console.WriteLine("== Debug Config Values ==");
// Console.WriteLine("DefaultConnection     : " + connStr);
// Console.WriteLine("FMPKey                : " + fmpKey);
// Console.WriteLine("JWT:Issuer            : " + jwtIssuer);
// Console.WriteLine("JWT:Audience          : " + jwtAudience);
// Console.WriteLine("JWT:SigningKey        : " + jwtSigningKey);



// var config = builder.Configuration;
// var ENV = config["ENV"];
// var reactAPI = "http://localhost:5173";
// if (ENV == "production")
// {
//     reactAPI = "http://13.201.166.186:5173";
// }

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy.WithOrigins("http://13.201.166.186:5173", "http://localhost:5173") // 👈 Exact origins
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials(); // ✅ Only works if origins are explicitly specified
        });
});

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.AddRazorPages();

// Configure sql server connection
// builder.Services.AddDbContext<ApplicationDbContext>(
//     options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
// );

// Method-1 Configure PostgreSQL connection
// var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Method-2
// var connectionString = builder.Configuration["DefaultConnection"];

// Method-3  DO THIS: Read directly from environment variable
// var connectionString = Environment.GetEnvironmentVariable("DefaultConnection");
// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseNpgsql(connectionString));

// Method-4
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 12;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SigningKey"]!)
        )
    };
});

// Dependency Injections
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<IStockRepository, StockRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<IFMPService, FMPService>();
builder.Services.AddHttpClient<IFMPService, FMPService>();

var app = builder.Build();

// Migrate database automatically
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();  // <--- This line does the migration at startup
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Ensure CORS is applied before authentication & authorization
app.UseCors("AllowFrontend");

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();
app.MapControllers();

app.Run();
