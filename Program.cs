using ASP_MVC.ExtendMethods;
using ASP_MVC.Models;
using ASP_MVC.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.EntityFrameworkCore;

namespace ASP_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                var connectString = builder.Configuration.GetConnectionString("ShopContext");
                options.UseSqlServer(connectString);
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddRazorPages(); // dang ky dich vu lien quan den RAZOR
            //builder.Services.AddTransient(typeof(ILogger<>), typeof(Logger<>));

            builder.Services.Configure<RazorViewEngineOptions>(options =>
            {
                // /view/controller/action.cshtml
                // /MyView/controller/action.cshtml

                // {0} -> ten action
                // {1} -> ten controller
                // {2} -> ten area

                options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);

            });

            //builder.Services.AddSingleton<ProductService>();
            //builder.Services.AddSingleton<ProductService, ProductService>();
            //builder.Services.AddSingleton(typeof(ProductService));
            builder.Services.AddSingleton(typeof(ProductService), typeof(ProductService));
            builder.Services.AddSingleton<PlanetService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.AddStatusCodePage(); // tuy bien loi response: 400-500 

            app.UseRouting();

            app.UseAuthorization(); // xac thuc quyen truy cap
            app.UseAuthentication(); // xac dinh danh tinh

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/sayhi", async context =>
                {
                    await context.Response.WriteAsync($"Hello ASPNET MVC");
                });

                //endpoints.MapControllers();
                //endpoints.MapControllerRoute();
                //endpoints.MapDefaultControllerRoute();
                //endpoints.MapAreaControllerRoute();

                //[AcceptVerbs]

                //[Route]

                //[HttpGet]
                //[HttpPost]
                //[HttpPut]
                //[HttpDelete]
                //[HttpHead]
                //[HttpPath]


                // url => start-here
                // controller => 
                // action => 
                // area => 

                endpoints.MapControllers();

                // xemsanpham/1
                // url bat ky/id
                endpoints.MapControllerRoute(
                    name: "first",
                    pattern: "/{url:regex(^((xemsanpham)|(viewProduct))$)}/{id:range(2,3)}",
                    defaults: new
                    {
                        controller = "First",
                        action = "ViewProduct",
                        //id = 1,
                    }
                //constraints: new
                //{
                //url = new RegexRouteConstraint(@"^((xemsanpham)|(viewProduct))$"),
                //id = new RangeRouteConstraint(2, 4)

                //url = "xemsanpham",
                //url = new StringRouteConstraint("xemsanpham"), 
                //}
                );

                endpoints.MapAreaControllerRoute(
                    name: "admin",
                    areaName: "Admin",
                    pattern: "{controller}/{action=Index}/{id?}"
                );

                endpoints.MapAreaControllerRoute(
                   name: "contact",
                   areaName: "Contact",
                   pattern: "{controller}/{action=Index}/{id?}"
               );


                endpoints.MapAreaControllerRoute(
                    name: "database",
                    areaName: "Database",
                    pattern: "{controller}/{action=Index}/{id?}"
                );


                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
                // sfart-here  || start-here/1
                //defaults : new
                //{
                //    controller = "First",
                //    action = "ViewProduct",
                //    id = 3
                //}


                endpoints.MapRazorPages();
            });


            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{controller=Home}/{action=Index}/{id?}");

            // URL : /{controller}/{action}/{id?}
            // ABC/XYZ => controller = ABC, Action = XYZ


            app.MapRazorPages();

            app.Run();
        }
    }
}

/**
 * dotnet aspnet-codegenerator -h
 * dotnet aspnet-codegenerator controller -name Contact -namespace ASP_MVC.Areas.Contact.Controllers -m ASP_MVC.Models.Contact -udl -dc ASP_MVC.Models.AppDbContext -outDir Areas/Contact/Controllers/
 */
