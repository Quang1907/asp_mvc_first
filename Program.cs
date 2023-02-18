using ASP_MVC.Services;
using Microsoft.AspNetCore.Mvc.Razor;

namespace ASP_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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

            app.UseRouting();

            app.UseAuthorization(); // xac thuc quyen truy cap
            app.UseAuthentication(); // xac dinh danh tinh


            // URL : /{controller}/{action}/{id?}
            // ABC/XYZ => controller = ABC, Action = XYZ
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}