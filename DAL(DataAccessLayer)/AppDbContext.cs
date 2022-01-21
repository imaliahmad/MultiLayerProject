using BOL_BusinessObjectLayer_;
using DAL_DataAccessLayer_.ExtensionMethods;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL_DataAccessLayer_
{
    public class AppDbContext: IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Seed();
            //seeding
        }
        public DbSet<Categorys> Categorys { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<AppUsers> AppUsers { get; set; }
    }
}
