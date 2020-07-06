using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLayihe.Models;

namespace WebLayihe.ViewModels
{
    public class VmCourse
    {
        public Header Header { get; set; }

        public List<Course> Courses { get; set; }
    }
}