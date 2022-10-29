using Dance;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Security.Claims;

namespace TestApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<FormOptions>(options =>
            {
                options.MemoryBufferThreshold = int.MaxValue;
            });
            services.AddSingleton<AuthManager>();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => //CookieAuthenticationOptions
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/auth");
                });

            services.AddAuthorization();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();



            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                
                endpoints.MapPost("/uploader", async context =>
                {
                    IFormFile file = context.Request.Form.Files.FirstOrDefault();
                    Console.WriteLine(file.ContentType);
                    using(Stream stream = new FileStream(@"C:\Users\Diman\source\repos\TestApp\TestApp\Pages\123.jpg", FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                });
                endpoints.MapGet("/", async context =>
                {
                    string page = File.ReadAllText("Pages/index.html");
                    await context.Response.WriteAsync(page);
                });
                endpoints.MapGet("/auth1", async context =>
                {
                    string page = File.ReadAllText("Pages/pages/auth/auth.css");
                    await context.Response.WriteAsync(page);
                });
                endpoints.MapGet("/styles", async context =>
                {
                    string page = File.ReadAllText("Pages/styles/main.css");
                    await context.Response.WriteAsync(page);
                });
                endpoints.MapGet("/logo", async context =>
                {
                    string page = File.ReadAllText(@"C:\\Users\\ASUS\\OneDrive\\Рабочий стол\\321\\TestApp\\Pages\\assets\\images\\logo.svg");
                    await context.Response.WriteAsync(page);
                });
                endpoints.MapGet("/auth", async context =>
                {
                    string page = File.ReadAllText("Pages/pages/auth/auth.html");
                    await context.Response.WriteAsync(page);
                });
                endpoints.MapGet("/1", async context =>
                {
                    string page = File.ReadAllText("Pages/htmlpage.html");
                    await context.Response.WriteAsync(page);
                });
                endpoints.MapPost("/login", async context => {
                    var credentials = await context.Request.ReadFromJsonAsync<Credentials>();
                    var lm = app.ApplicationServices.GetService<AuthManager>();
                    if (lm.Login(credentials.Login, credentials.Password) == true)
                    {
                        List<Claim> claims = new List<Claim>()
                        {
                            new Claim(ClaimsIdentity.DefaultNameClaimType, credentials.Login)
                        };
                        ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                        await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
                        
                    }
                    if(lm.Login(credentials.Login, credentials.Password) == true)
                    {
                        await context.Response.WriteAsJsonAsync("true");
                    }
                    else
                    {
                        await context.Response.WriteAsJsonAsync("false");
                    }

                });
            });
        }
    }
}
