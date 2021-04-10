using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopBridge.Models
{
    public class ItemModel
    {
        public int ItemId { get; set; }
        [Required]
        [MaxLength(20,ErrorMessage ="You need to keep the name to a max of 20 characters")]
        [MinLength(3,ErrorMessage ="You need to enter atleast 3 characters for an Item Name")]
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1,50,ErrorMessage ="Value lies outside of 1 to 50 range")]
        public decimal Price { get; set; }
        [Required]
        [Range(1,20,ErrorMessage ="You can add upto 20 quantities")]
        public int Quantity { get; set; }
    }
}
