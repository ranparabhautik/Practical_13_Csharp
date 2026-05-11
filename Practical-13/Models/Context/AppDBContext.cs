using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Practical_13.Models.entities;

namespace Practical_13.Models.Context
{
    public class AppDBContext:DbContext
    {
        public AppDBContext() : base("connection") { 
        
        }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Employees_Task2> Employees_Task2 { get; set; }
        public DbSet<Designation> Designations { get; set; }

    }
}