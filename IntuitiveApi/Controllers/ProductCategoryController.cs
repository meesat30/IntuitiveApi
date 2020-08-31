using System;
using System.Linq;
using System.Threading.Tasks;
using IntuitiveApi.Data;
using IntuitiveApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntuitiveApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductCategoryController: ControllerBase
    {
        private readonly DemoDBContext _db;

        public ProductCategoryController(DemoDBContext db)
        {
            _db = db;
        }

        // Action Methods

        [HttpGet]
        public IActionResult GetProductCategories()
        {
            return Ok(_db.ProductCategories.ToList());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductCategory>> GetProductCategories(int id)
        {
            var category = await _db.ProductCategories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] ProductCategory objCategory)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult("Error While Creating New Category");
            }
            _db.ProductCategories.Add(objCategory);
            await _db.SaveChangesAsync();

            return new JsonResult("Category Created Successfully");

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory( int id,  ProductCategory objCategory)
        {
            if (objCategory == null || id != objCategory.CategoryId)
            {
                return new JsonResult("Category Was Not Found");
            }
            else
            {
                _db.ProductCategories.Update(objCategory);
                await _db.SaveChangesAsync();
                return new JsonResult("Category Was Updated Successfully");
            }
        }

        [HttpDelete("{CategoryId}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int CategoryId)
        {
            var findCategory = await _db.ProductCategories.FindAsync(CategoryId);
            if (findCategory == null)
            {
                return NotFound();
            }
            else
            {
                _db.ProductCategories.Remove(findCategory);
                await _db.SaveChangesAsync();
                return new JsonResult("Category Was Deleted Successfully");
            }
        }
    }
}
