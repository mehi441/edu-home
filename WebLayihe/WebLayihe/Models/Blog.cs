using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLayihe.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Title { get; set; }

        public DateTime CreateDate { get; set; }

        [Column(TypeName ="ntext")]
        [Required]
        public string Content { get; set; }

        [MaxLength(50)]
        [Required]
        public string Author { get; set; }

        public int ViewCount { get; set; }

        [MaxLength(200)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [ForeignKey("Catagory")]
        public int CatagoryId { get; set; }

        public BlogCatagory Catagory { get; set; }


    }
}