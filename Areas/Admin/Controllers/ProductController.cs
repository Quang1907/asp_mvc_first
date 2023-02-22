using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("san-pham")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        // Areas/AreaName/Views/ControllerName/ActionName.cshtml

        public IActionResult Index()
        {
            var products = _productService.OrderBy(p => p.Name).ToList();
            return View(products);
        }
    }
}