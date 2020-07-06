using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebLayihe.Models;

namespace WebLayihe.DAL
{
    public class EduHomeContex:DbContext
    {

        public EduHomeContex() : base("EduHomeCon")
        {

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutSlide> AboutSlides { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCatagory> BlogCatagories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseCatagory> CourseCatagories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventCatagory> EventCatagories { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<HomeSlide> HomeSlides { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<SettingSocial> SettingSocials { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<SpeakerEvent> SpeakerEvents { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }

    }
}