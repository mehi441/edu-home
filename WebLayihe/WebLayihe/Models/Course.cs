using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLayihe.Models
{
    public class Course
    {
        public int Id { get; set; }

        [MaxLength(70)]
        [Required]
        public string Title { get; set; }

        [MaxLength(600)]
        [Required]
        public string Explanation { get; set; }

        [Column(TypeName ="ntext")]
        [Required]
        public string Content { get; set; }

        [MaxLength(200)]
        public string Image { get; set; }
        
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }


        [ForeignKey("Catagory")]
        public int CatagoryId { get; set; }
        public CourseCatagory Catagory { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public int ClassDuration { get; set; }

        [MaxLength(30)]
        [Required]
        public string SkillLevel { get; set; }

        [MaxLength(20)]
        [Required]
        public string Language { get; set; }

        [Required]
        public int StudentCount { get; set; }

        [MaxLength(30)]
        public string Assesments { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

    }
}