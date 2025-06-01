using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NetCoreAI.Project01_ApiDemo.Context;
using NetCoreAI.Project01_ApiDemo.Entities;

namespace NetCoreAI.Project01_ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApiContext _context;

        public CustomersController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult CustomerList()
        {
            var customers = _context.Customers.ToList();
            return Ok(customers);
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is null.");
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok("Müşteri Ekleme İşlemi Başarılı");
        }


        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound("Müşteri Bulunamadı.");
            }

            _context.Customers.Remove(customer);
            _context.SaveChanges();
            return Ok("Müşteri Silme İşlemi Başarılı");
        }

        [HttpGet("GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer == null)
            {
                return NotFound("Müşteri Bulunamadı.");
            }

            return Ok(customer);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer data is null.");
            }

           _context.Customers.Update(customer);
           _context.SaveChanges();
            return Ok("Müşteri Güncelleme İşlemi Başarılı");
        }
    }
}
