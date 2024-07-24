using assessment_platform_developer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace assessment_platform_developer.Repositories
{
    public class QueryDBContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}