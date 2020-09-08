using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntuitiveApi.Data;
using IntuitiveApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoggerService;

namespace IntuitiveApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController:ControllerBase
    {
        private readonly DemoDBContext _db;

        public ProductController(DemoDBContext db)
        {
            _db = db;
        }

        // Action Methods

        [HttpGet]
        public IActionResult GetProduct()

        {
           
            return Ok(_db.Products.Include(c => c.ProductCategory).ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            // var product = await _db.Products.Include(m=>m.ProductCategory).FirstOrDefaultAsync(m=>m.Productid==id);
            var product = await _db.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            return product;
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product objProduct)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Error While Creating New Product");
            }
            _db.Products.Add(objProduct);
            await _db.SaveChangesAsync();

            return new JsonResult("Product Created Successfully");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product objProduct)
        {
            if (objProduct == null || id != objProduct.ProductId)
            {
                return new JsonResult("Product Was Not Found");
            }
            else
            {
                _db.Products.Update(objProduct);
                await _db.SaveChangesAsync();
                return new JsonResult("Product Was Updated Successfully");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var findProduct = await _db.Products.FindAsync(id);
            if (findProduct == null)
            {
                return NotFound();
            }
            else
            {
                _db.Products .Remove(findProduct);
                await _db.SaveChangesAsync();
                return new JsonResult("Product Was Deleted Successfully");
            }
        }
    }
}
