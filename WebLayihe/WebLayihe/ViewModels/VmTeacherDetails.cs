using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLayihe.Models;

namespace WebLayihe.ViewModels
{
    public class VmTeacherDetails
    {
        public Header Header { get; set; }

        public Teacher Teacher { get; set; }

        public Occupation Occupation { get; set; }

        public List<Social> Socials { get; set; }
    }
}