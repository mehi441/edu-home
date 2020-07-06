using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLayihe.Models
{
    public class Header
    {
        public int Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Title { get; set; }
        
        [MaxLength(200)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [MaxLength(50)]
        [Required]
        public string Page { get; set; }
    }
}