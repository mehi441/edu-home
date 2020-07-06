using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLayihe.Models
{
    public class AboutSlide
    {
        public int Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string Fullname { get; set; }

        [MaxLength(300)]
        [Required]
        public string Content { get; set; }

        [MaxLength(200)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public int OccupationId { get; set; }

        public Occupation Occupation { get; set; }
    }
}