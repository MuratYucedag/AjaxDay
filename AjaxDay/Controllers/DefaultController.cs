using AjaxDay.DAL;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AjaxDay.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _context;
        public DefaultController(Context context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            var values = _context.Products.ToList();
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            var values = JsonConvert.SerializeObject(product);
            return Json(values);
        }

        public IActionResult DeleteProduct(int id)
        {
            var value = _context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return NoContent();
        }

        public IActionResult GetProduct(int id)
        {
            var value = _context.Products.Find(id);
            var jsonValues = JsonConvert.SerializeObject(value);
            return Json(jsonValues);
        }

        public IActionResult UpdateProduct(Product product)
        {
            var value = _context.Products.Find(product.ProductId);
            value.Name = product.Name;
            value.Price = product.Price;
            value.Stock = product.Stock;
            _context.SaveChanges();
            return NoContent();
        }
    }
}
