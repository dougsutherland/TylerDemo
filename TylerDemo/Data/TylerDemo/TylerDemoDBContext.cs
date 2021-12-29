using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TylerDemo.Models;

namespace TylerDemo.Data.TylerDemo
{
    public class TylerDemoDBContext : DbContext
    {
        public TylerDemoDBContext(DbContextOptions<TylerDemoDBContext> options): base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           
        }

        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeRole> EmployeeRole { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<OrganizationalChart> OrganizationalChart { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee").HasKey(x=>x.Id);
            modelBuilder.Entity<EmployeeRole>().ToTable("EmployeeRole").HasKey(x=>new {x.EmployeeId,x.RoleId });
            modelBuilder.Entity<Role>().ToTable("Role").HasKey(x=>x.Id);
        }
    }
}
