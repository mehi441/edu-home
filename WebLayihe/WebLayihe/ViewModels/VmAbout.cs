using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLayihe.Models;

namespace WebLayihe.ViewModels
{
    public class VmAbout
    {
        public Header Header { get; set; }

        public List<Teacher> Teachers { get; set; }

        public VmAboutSlider VmAboutSlider { get; set; }

        public VmNotice VmNotice { get; set; }

    }
}