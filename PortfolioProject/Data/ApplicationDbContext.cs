using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        //Declare the Video Model so that the Database has access to it and so the rest of our App
        public DbSet<Video> Videos { get; set; }

        public DbSet<Category> Categories { get; set; }
        public DbSet<FreelanceProject> FreelanceProjects { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
