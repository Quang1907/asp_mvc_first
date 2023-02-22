using ASP_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, IWebHostEnvironment env, ProductService productService)
        {
            this._logger = logger;
            this._env = env;
            this._productService = productService;
        }

        public IActionResult Index()
        {
            /** 
             * this.HttpContent
             * this.Request
             * this.RouteData xc
             * this.Response
             * 
             * this.User
             * this.ModelState
             * this.ViewData
             * this.ViewBag
             * this.Url
             * this.TempData
             * logger.Log(LogLevel.Warning, "Sfdsdf");
             */

            return View();
        }

        [TempData]
        public string StatusMessage { get; set; }

        [AcceptVerbs("POST", "GET")]
        public IActionResult ViewProduct(int? id)
        {
            //var product = (from p in _productService
            //               where p.Id == id
            //               select p).FirstOrDefault();
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                //TempData["StatusMessage"] = "Dang nhap";
                StatusMessage = "San pham ban yeu cau khong co";
                //return NotFound();
                return Redirect(Url.Action("Index", "Home"));
            }
            //return Content($"san pham id = {id}");
            ViewData["product"] = product;
            ViewData["Title"] = "Product detail";


            ViewBag.product = product;

            return View("ViewProduct2");
        }

        public void Nothing()
        {
            _logger.LogInformation("$%6456");
            Response.Headers.Add("hi", "chao ban");
        }

        public object Anything() => new int[] { 1, 2, 3, 4 };

        public IActionResult result()
        {
            return View();
        }

        /**
         *  Kiểu trả về                 | Phương thức
            ------------------------------------------------
            ContentResult               | Content()
            EmptyResult                 | new EmptyResult()
            FileResult                  | File()
            ForbidResult                | Forbid()
            JsonResult                  | Json()
            LocalRedirectResult         | LocalRedirect()
            RedirectResult              | Redirect()
            RedirectToActionResult      | RedirectToAction()
            RedirectToPageResult        | RedirectToRoute()
            RedirectToRouteResult       | RedirectToPage()
            PartialViewResult           | PartialView()
            ViewComponentResult         | ViewComponent()
            StatusCodeResult            | StatusCode()
            ViewResult                  | View()
         */

        public IActionResult hihi()
        {
            var a = "<h2>3e45</h2>";
            return Content(a, "text/plain");
        }

        public IActionResult Bird()
        {
            string filePath = Path.Combine(_env.ContentRootPath, "Files", "bird.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            string contentType = MimeKit.MimeTypes.GetMimeType(filePath);

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = filePath,
                Inline = true,
            };

            Response.Headers.Add("Content-Disposition", cd.ToString());

            return File(bytes, contentType);
        }

        public IActionResult IphonePrice()
        {
            return Json(
                new
                {
                    productName = "Iphone x",
                    price = 1000
                }
             );
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogWarning("Chuyen huong den " + url);
            return LocalRedirect(url);
        }

        public IActionResult Google()
        {
            var url = "https://google.com";
            _logger.LogWarning("Chuyen huong den " + url);
            return Redirect(url);
        }

        public IActionResult HelloView(string username)
        {

            if (string.IsNullOrEmpty(username))
            {
                username = "khach";
            }
            _logger.LogWarning(username);
            //return View((object) username);

            return View("Xinchao3");
        }
    }
}
