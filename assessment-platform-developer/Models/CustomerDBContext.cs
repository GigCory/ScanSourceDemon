using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace assessment_platform_developer.Models
{
    public class CommandDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}