using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLayihe.Models;

namespace WebLayihe.ViewModels
{
    public class VmEventDetail
    {
        public Header Header { get; set; }

        public Setting Setting { get; set; }

        public List<EventCatagory> EventCatagories { get; set; }

        public List<Blog> Blogs { get; set; }

        public Event Event { get; set; }

        public List<SpeakerEvent> SpeakerEvents { get; set; }



    }
}