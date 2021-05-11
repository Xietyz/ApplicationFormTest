using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAp.Models
{
    public class MyClassContext : DbContext
    {
        public MyClassContext(DbContextOptions<MyClassContext> options)
        : base(options)
        {
        }

        public DbSet<MyClass> TodoItems { get; set; }
    }
}
