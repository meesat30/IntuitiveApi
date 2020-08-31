using System;
using System.ComponentModel.DataAnnotations;

namespace IntuitiveApi.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        
    }
}
        