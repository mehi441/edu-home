using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLayihe.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Fullname { get; set; }

        [Column(TypeName ="ntext")]
        [Required]
        public string Content { get; set; }

        [MaxLength(200)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [MaxLength(30)]
        [Required]
        public string Email { get; set; }

        [MaxLength(20)]
        [Required]
        public string Phone { get; set; }

        [MaxLength(30)]
        [Required]
        public string Skype { get; set; }

        [Required]
        public int Language { get; set; }

        [Required]
        public int TeamLeader { get; set; }

        [Required]
        public int Development { get; set; }

        [Required]
        public int Design { get; set; }

        [Required]
        public int Innovation { get; set; }

        [Required]
        public int Communication { get; set; }

        public int OccupationId { get; set; }
        public Occupation Occupation { get; set; }

        public List<Social> Socials { get; set; }
    }
}