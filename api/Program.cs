using api.Data;
using Microsoft.EntityFrameworkCore;
// using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();



// builder.Services.AddSwaggerGen();

// builder.Services.AddSwaggerGen(option =>
// {
//     option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
//     option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//     {
//         In = ParameterLocation.Header,
//         Description = "Please enter a valid token",
//         Name = "Authorization",
//         Type = SecuritySchemeType.Http,
//         BearerFormat = "JWT",
//         Scheme = "Bearer"
//     });
//     option.AddSecurityRequirement(new OpenApiSecurityRequirement
//     {
//         {
//             new OpenApiSecurityScheme
//             {
//                 Reference = new OpenApiReference
//                 {
//                     Type=ReferenceType.SecurityScheme,
//                     Id="Bearer"
//                 }
//             },
//             new string[]{}
//         }
//     });
// });


builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();


// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(
//         builder => builder.WithOrigins("http://localhost:5000", "https://localhost:5001")
//                           .AllowAnyHeader()
//                           .AllowAnyMethod()
//                           .AllowCredentials());
// });


app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.MapControllers();

app.Run();
