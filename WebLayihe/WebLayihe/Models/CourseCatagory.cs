using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLayihe.Models
{
    public class CourseCatagory
    {
        public int Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

        public List<Course> Courses { get; set; }
    }
}