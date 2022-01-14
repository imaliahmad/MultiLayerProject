using BOL_BusinessObjectLayer_;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_DataAccessLayer_
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Categorys> Categorys { get; set; }
        public DbSet<Products> Products { get; set; }
    }
}
