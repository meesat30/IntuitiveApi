using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntuitiveApi.Models
{
    public class Product
    {
        [Key]
        public int Productid { get; set; }
        public string Desc { get; set; }
        public int CategoryId { get; set; }
        public int Cost { get; set; }
        [ForeignKey("CategoryId")]
        public ProductCategory ProductCategory { get; set; }

    }
}
