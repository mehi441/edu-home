using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebLayihe.Models
{
    public class Event
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [MaxLength(150)]
        [Required]
        public string Title { get; set; }

        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime CreatedDate { get; set; }


        [Display(Name = "Start Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime StartTime { get; set; }



        [Display(Name = "End Time")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime EndTime { get; set; }


        [MaxLength(150)]
        [Required]
        public string Venue { get; set; }

        [Column(TypeName ="ntext")]
        [Required]
        public string Content { get; set; }


        [ForeignKey("Catagory")]
        [Display(Name = "Catagory")]
        public int CatagoryId { get; set; }
        public EventCatagory Catagory { get; set; }


        [NotMapped]
        public int[] SpeakerId { get; set; }

        public List<SpeakerEvent> SpeakerEvents { get; set; }
    }
}