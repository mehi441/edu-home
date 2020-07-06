using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLayihe.Models;

namespace WebLayihe.ViewModels
{
    public class VmBlog
    {
        public Header Header { get; set; }

        public List<BlogCatagory> BlogCatagories { get; set; }

        public Setting Setting { get; set; }

        public List<Blog> Blogs { get; set; }

        public int PageCount { get; set; }

        public int CurrentPage { get; set; }
    }
}