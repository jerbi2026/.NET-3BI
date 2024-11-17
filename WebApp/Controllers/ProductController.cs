using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        
        private static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Box A", Quantity = 10 },
            new Product { Id = 2, Name = "Box B", Quantity = 5 }
        };

        //private Product CreateProduct() // new Product { Id = 1, Name = "Box A", Quantity = 10 },
        //{
        //    var p = new Product();
        //    p.Id = 1;
        //    p.Name = "Box A";
        //    p.Quantity = 10;
        //}

        [HttpGet] //Get ../product/
                  //[HttpGet("all")] //Get ../product/all
        public IEnumerable<Product> Get()
        {
            return Products;
        }

        [HttpGet("{id}")] //Get ../product/1
        [HttpGet("get/{id}")] //Get ../product/get/1
        public Product Get(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }

        [HttpPost]
        public void Add([FromBody] Product product)
        {
            product.Id = Products.Max(p => p.Id) + 1;
            Products.Add(product);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Product updatedProduct)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Quantity = updatedProduct.Quantity;
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Products.Remove(product);
            }
        }


    }
}
