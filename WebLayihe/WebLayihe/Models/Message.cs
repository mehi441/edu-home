using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLayihe.Models
{
    public class Message
    {
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(30)]
        [Required]
        public string Email { get; set; }

        [MaxLength(70)]
        [Required]
        public string Subject { get; set; }

        [MaxLength(500)]
        [Required]
        public string Content { get; set; }

        public DateTime AddedDate { get; set; }

    }
}