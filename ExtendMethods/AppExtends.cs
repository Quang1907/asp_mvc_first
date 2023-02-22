using Microsoft.AspNetCore.Builder;
using System.Net;

namespace ASP_MVC.ExtendMethods
{
    public static class AppExtends
    {
        public static void AddStatusCodePage(this IApplicationBuilder app)
        {
            app.UseStatusCodePages(appError =>
            {
                appError.Run(async context =>
                {
                    var response = context.Response;
                    var code = response.StatusCode;

                    var content = $@"<html>
                            <head>
                                <meta charset='UTF-8' />
                                <title>Loi {code}</title>
                            </head>
                            <body>
                                <p style='color:red;background:green'>Co loi xay ra: {code} - {(HttpStatusCode)code}</p>
                            </body>
                    </html>";

                    await response.WriteAsync(content);
                });
            }); // code 400 - 500
        }
    }
}
