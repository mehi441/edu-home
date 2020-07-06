using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLayihe.Models
{
    public class Occupation
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }


        public List<AboutSlide> AboutSlides { get; set; }
        public List<Teacher> Teachers { get; set; }
        public List<Speaker> Speakers { get; set; }








    }
}