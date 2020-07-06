using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using WebLayihe.Models;

namespace WebLayihe.ViewModels
{
    public class VmCourseDetail
    {
        public Header Header { get; set; }

        public Setting Setting { get; set; }

        public Course Course { get; set; }

        public List<CourseCatagory> CourseCatagories { get; set; }

        public List<Blog> Blogs { get; set; }
    }
}