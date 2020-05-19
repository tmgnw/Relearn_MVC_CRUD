using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Relearn_MVC_CRUD.Models
{
    [Table("Tb_Item")]
    public class Item
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Price is required")]
        public int Price { get; set; }
        
        [Required(ErrorMessage = "Stock is required")]
        public int Stock { get; set; }
        
        [Display(Name = "Supplier")]
        public int SupplierID { get; set; }

        public virtual Supplier Supplier { get; set; }

        public Item()
        {

        }
    }
}