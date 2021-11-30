using BLOGN.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLOGN.Data
{
     public class ApplicationDbContext : DbContext
     {
          public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
          {
          }

          public DbSet<Category> Categories { get; set; }
          public DbSet<Article> Articles { get; set; }
          public DbSet<User> Users { get; set; }
     }
}
