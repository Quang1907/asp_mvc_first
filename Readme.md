## Controller 
- la 1 lop ke thua tu lop controller: Microsoft.AspNetCore.Mvc.Controller
- Action trong controller la 1 phuong thuc public ( ko duoc static )
- Action tra ve bat ky kieu du lieu nao, thuong la IActionResult
- Cac dich vu injection vao controller qua ham tao
## view 
- la file.cshtml
- view cho Action luu tai: "/View/ControllerName/ActionName.cshtml"
- Them thu muc luu tru view:
```
// {0} -> ten action
// {1} -> ten controller
// {2} -> ten areas 
options.ViewLocationFormats.Add("/MyView/{1}/{0}" + RazorViewEngine.ViewExtension);
```
## Truyen du lieu sang view 
- Model
- ViewData
- ViewBag
- TempData

## areas
- la ten dung de routing
- la cau truc thu muc chua mvc
- thiet lap area cho controller bang ```[Area("AreaName")]```
```
dotnet aspnet-codegenerator area Product
```