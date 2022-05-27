namespace Auth.Jwt.Web
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading.Tasks;
    using Auth.Jwt.Web.Contracts.Services;
    using Auth.Jwt.Web.Contracts.Settings;
    using Auth.Jwt.Web.Services;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Localization;
    using Microsoft.AspNetCore.Mvc.Razor;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Options;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRequestLocalization(
                app.ApplicationServices.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);
            app.UseStatusCodePages(
                context =>
                {
                    var response = context.HttpContext.Response;
                    if (!context.HttpContext.Request.Path.Value.StartsWith(
                            "/api",
                            StringComparison.InvariantCultureIgnoreCase) &&
                        response.StatusCode == StatusCodes.Status401Unauthorized)
                    {
                        context.HttpContext.Response.Redirect("/");
                    }

                    return Task.CompletedTask;
                });
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                {
                    endpoints.MapControllerRoute(
                        "default",
                        "{controller=Home}/{action=Index}/{id?}");
                });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions<JwtSettings>().Bind(this.Configuration.GetSection("Jwt")).ValidateDataAnnotations();

            services.Configure<RequestLocalizationOptions>(
                options =>
                {
                    var cultures = new List<CultureInfo>
                    {
                        new CultureInfo("de"),
                        new CultureInfo("en")
                    };
                    options.DefaultRequestCulture = new RequestCulture(cultures[0]);
                    options.SupportedCultures = cultures;
                    options.SupportedUICultures = cultures;
                });
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();
            services.AddControllersWithViews();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddSingleton<IDatabaseService, DatabaseService>();
            services.AddSingleton<IHashService, HashService>();
            services.AddSingleton<ISecretService, SecretService>();
            services.AddScoped<IJwtService, JwtService>();

            services.AddAuthentication(
                    options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    })
                .AddJwtBearer(
                    options =>
                    {
                        var jwtService = services.BuildServiceProvider().GetService<IJwtService>();
                        jwtService.SetOptions(options);
                    });
        }
    }
}
