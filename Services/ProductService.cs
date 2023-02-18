using ASP_MVC.Models;

namespace ASP_MVC.Services
{
    public class ProductService : List<Product>
    {
        public ProductService()
        {
            this.AddRange(new Product[] {
                new Product () { Id = 1, Name = "1", Price = 22},
                new Product () { Id = 2, Name = "2", Price = 222},
                new Product () { Id = 3, Name = "3", Price = 2222},
                new Product () { Id = 4, Name = "4", Price = 22222},
                new Product () { Id = 5, Name = "5", Price = 222222},
            });
        }
    }
}
