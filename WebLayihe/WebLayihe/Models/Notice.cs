using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLayihe.Models
{
    public class Notice
    {
        public int Id { get; set; }

        public DateTime AddedDate { get; set; }

        [MaxLength(400)]
        [Required]
        public string Content { get; set; }
    }
}