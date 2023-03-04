using Medical_laboratory.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_laboratory
{
    class CurrentList
    {
        public class ApplicationContext : DbContext
        {
            public DbSet<Employee> Employees { get; set; } = null!;
            public DbSet<History> Histories { get; set; } = null!;
            public DbSet<Result> Results { get; set; } = null!;
            public DbSet<Role> Roles { get; set; } = null!;
            public DbSet<Service> Services { get; set; } = null!;
            public DbSet<User> Users { get; set; } = null!;


            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Server=ngknn.ru;Database=43P_BaseForMedicalLaboratoryZelentsov;User ID = 33П; Password = 12357; TrustServerCertificate = true");
            }
        }
    }
}
