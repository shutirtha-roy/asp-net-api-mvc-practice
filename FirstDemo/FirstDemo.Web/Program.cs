using Autofac;
using Autofac.Extensions.DependencyInjection;
using FirstDemo.Infrastructure;
using FirstDemo.Infrastructure.DbContexts;
using FirstDemo.Infrastructure.Entities;
using FirstDemo.Infrastructure.Securities;
using FirstDemo.Infrastructure.Services;
using FirstDemo.Web;
using FirstDemo.Web.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Events;
using System.Reflection;
using System.Text;

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    var assemblyName = Assembly.GetExecutingAssembly().FullName;

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder => {
        containerBuilder.RegisterModule(new WebModule());
        containerBuilder.RegisterModule(new InfrastructureModule(connectionString, assemblyName));
    });

    builder.Host.UseSerilog((ctx, lc) => lc
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .ReadFrom.Configuration(builder.Configuration)
    );


    builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(
            connectionString,
            m => m.MigrationsAssembly(assemblyName)
        )
    );

    builder.Services.AddDatabaseDeveloperPageExceptionFilter();

    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services
    .AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddUserManager<ApplicationUserManager>()
    .AddRoleManager<ApplicationRoleManager>()
    .AddSignInManager<ApplicationSignInManager>()
    .AddDefaultTokenProviders();

    builder.Services.AddAuthentication()
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => {
        options.LoginPath = new PathString("/Account/Login");
        options.AccessDeniedPath = new PathString("/Account/Login");
        options.LogoutPath = new PathString("/Account/Login");
        options.Cookie.Name = "FirstDemoPortal.Identity"; //We can customize cookie name
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromHours(1);
    })
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
        };
    });

    builder.Services.Configure<IdentityOptions>(options =>
    {
        // Password settings.
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 0;

        // Lockout settings.
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
        options.Lockout.MaxFailedAccessAttempts = 5;
        options.Lockout.AllowedForNewUsers = true;

        // User settings.
        options.User.AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
        options.User.RequireUniqueEmail = true;
    });

    builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("CourseManagementPolicy", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireRole("Admin");
            policy.RequireRole("Teacher");
        });

        //options.AddPolicy("CourseViewPolicy", policy =>
        //{
        //    policy.RequireAuthenticatedUser();
        //    policy.RequireClaim("ViewCourse", "true");
        //});

        options.AddPolicy("CourseCreatePolicy", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("CreateCourse", "true");
        });

        options.AddPolicy("CourseViewRequirementPolicy", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.Requirements.Add(new CourseViewRequirement());
        });

        options.AddPolicy("ApiRequirementPolicy", policy =>
        {
            policy.AuthenticationSchemes.Clear();
            policy.AuthenticationSchemes.Add(JwtBearerDefaults.AuthenticationScheme);
            policy.RequireAuthenticatedUser();
            policy.Requirements.Add(new ApiRequirement());
        });
    });

    builder.Services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(30);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });

    builder.Services.AddSingleton<IAuthorizationHandler, CourseViewRequirementHandler>();

    builder.Services.AddSingleton<IAuthorizationHandler, ApiRequirementHandler>();

    builder.Services.AddControllersWithViews();

    //builder.Services.AddTransient<ICourseModel, CourseModel>();
    //builder.Services.AddSingleton<ICourseModel, CourseModel>();
    //builder.Services.AddScoped<ICourseModel, CourseModel>();


    var app = builder.Build();

    Log.Information("Application Starting.");
    
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.UseSession();

    //At first it will check area then it will check the default one
    app.MapControllerRoute(
        name: "areas",
          pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}