using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLayihe.Models;

namespace WebLayihe.ViewModels
{
    public class VmNotice
    {

        public About About { get; set; }

        public List<Notice> Notices { get; set; }

    }
}