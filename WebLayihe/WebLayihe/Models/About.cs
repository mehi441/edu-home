using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLayihe.Models
{
    public class About
    {
        public int Id { get; set; }

        [Column(TypeName ="ntext")]
        [Required]
        public string Content { get; set; }

        [MaxLength(200)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [MaxLength(200)]
        [Required]
        public string VideoTitle { get; set; }

        [MaxLength(200)]
        [Required]
        public string VideoLink { get; set; }

        [MaxLength(200)]
        public string VideoBgImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase VideoBgImageFile { get; set; }

        [MaxLength(200)]
        [Required]
        public string NoticeTitle { get; set; }
    }
}