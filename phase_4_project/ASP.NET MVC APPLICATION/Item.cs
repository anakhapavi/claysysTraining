using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.IO;

namespace MVC_ProductApplication.Models
{
    public class Item
    {
        [Key]
        public int id {get; set;}

        [Required]
        [DisplayName("Item Name")]
        public string name { get; set;}

        [Required]
        [DisplayName("Price")]
        public decimal price { get; set;}

        [Required]
        [DisplayName("Quantity")]
        public int qty { get; set;}

        [Required]
        [DisplayName("Image")]
        public HttpPostedFileBase image { get; set; }


    }
}
