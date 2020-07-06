using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLayihe.Models;

namespace WebLayihe.ViewModels
{
    public class VmHome
    {
        public List<HomeSlide> HomeSlides { get; set; }

        public List<Teacher> Teachers { get; set; }

        public List<Course> Courses { get; set; }

        public VmNotice VmNotice { get; set; }

        public List<Event> Events { get; set; }

        public List<Blog> Blogs { get; set; }

        public VmAboutSlider VmAboutSlider { get; set; }
    }
}