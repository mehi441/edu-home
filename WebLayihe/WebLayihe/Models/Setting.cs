using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLayihe.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Logo { get; set; }

        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }
        
        [MaxLength(20)]
        [Required]
        public string NavbarPhone { get; set; }

        [MaxLength(200)]
        public string BgImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase BgImageFile { get; set; }

        [MaxLength(400)]
        [Required]
        public string Content { get; set; }

        [MaxLength(50)]
        [Required]
        public string Copyright { get; set; }

        [MaxLength(70)]
        [Required]
        public string FistAddress { get; set; }

        [MaxLength(70)]
        public string SecondAddress { get; set; }

        [MaxLength(20)]
        [Required]
        public string FirstPhone { get; set; }

        [MaxLength(20)]
        public string SecondPhone { get; set; }

        [MaxLength(30)]
        [Required]
        public string Email { get; set; }

        [MaxLength(200)]
        public string SidebarImage { get; set; }

        [NotMapped]
        public HttpPostedFileBase SidebarImageFile { get; set; }

        public List<SettingSocial> SettingSocials { get; set; }
    }
}