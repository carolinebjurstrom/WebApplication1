using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class WebApplication1DbContext : DbContext
    {
        public WebApplication1DbContext(DbContextOptions<WebApplication1DbContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
    }
}

