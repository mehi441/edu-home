using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebLayihe.Models
{
    public class SettingSocial
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; }

        [MaxLength(100)]
        [Required]
        public string Icon { get; set; }

        [MaxLength(100)]
        [Required]
        public string Link { get; set; }

        public int SettingId { get; set; }

        public Setting Setting { get; set; }

    }
}