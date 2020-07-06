using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLayihe.Models;

namespace WebLayihe.ViewModels
{
    public class VmEvent
    {
        public Header Header { get; set; }

        public List<Event> Events { get; set; }

        public List<EventCatagory> EventCatagories { get; set; }

        public Setting Setting { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}