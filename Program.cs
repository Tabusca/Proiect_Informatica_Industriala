using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using V3.Data;
using V3.Models;
using Microsoft.AspNetCore.Authorization;


var builder = WebApplication.CreateBuilder(args);

// 1. Configure services

// 1.1. DbContext for SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// 1.2. ASP.NET Core Identity
builder.Services
    .AddIdentity<Users, IdentityRole>(options =>
    {
        // password policies
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 8;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;

        // user policies
        options.User.RequireUniqueEmail = true;

        // sign-in policies
        options.SignIn.RequireConfirmedEmail = false;
        options.SignIn.RequireConfirmedPhoneNumber = false;
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

// 1.3. Cookie authentication settings
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.LoginPath = "/api/account/login";
    options.LogoutPath = "/api/account/logout";
    options.AccessDeniedPath = "/api/account/accessdenied";
});

// 1.4. CORS policy for React
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

// 1.5. MVC controllers & views
builder.Services.AddControllersWithViews();


var app = builder.Build();

// 2. Middleware pipeline

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 2.1. HTTP ? HTTPS, static files
app.UseHttpsRedirection();
app.UseStaticFiles();

// 2.2. Routing
app.UseRouting();

// 2.3. CORS before auth
app.UseCors("AllowReactApp");

// 2.4. Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// 2.5. Map API controllers
app.MapControllers();

// 2.6. Debug endpoint: list all routes
app.MapGet("/__routes", (EndpointDataSource ds) =>
    ds.Endpoints
      .OfType<RouteEndpoint>()
      .Select(e => new {
          Route = e.RoutePattern.RawText,
          Methods = e.Metadata
                       .OfType<HttpMethodMetadata>()
                       .FirstOrDefault()?
                       .HttpMethods
      })
);

// 2.7. SPA fallback
app.MapFallbackToFile("index.html");

app.Run();
