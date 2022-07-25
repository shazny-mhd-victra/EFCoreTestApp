using DAL.Db.Entities;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.AppDbContext
{
    public class dbcontext : DbContext
    {
        public dbcontext(DbContextOptions<dbcontext> options) : base(options)
        {

        }

        public DbSet<Priority>? Priorities { get; set; }
        public DbSet<News>? News { get; set; }
    }
}
