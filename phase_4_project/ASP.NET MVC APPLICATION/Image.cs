using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_ProductApplication.Models
{
    public class Image
    {
        [Key]
        public int id { get; set; }

        [Required]
        [DisplayName("Item Name")]
        public string imgname { get; set; }

        [Required]
        public byte[] imgpath { get; set; }
    }
}
