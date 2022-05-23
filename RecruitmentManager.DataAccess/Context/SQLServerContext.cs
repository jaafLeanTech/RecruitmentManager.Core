using Microsoft.EntityFrameworkCore;
using RecruitmentManager.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentManager.DataAccess.Context
{
    public class SqlServerContext: DbContext
    {
        private readonly string _connectionString = string.Empty;

        public SqlServerContext()
        {
            _connectionString = @"Data Source = DESKTOP-V89KSU6\SQLEXPRESS; Initial Catalog = RecruitmentManager; Integrated Security = true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            //ConnectionString=
            //Servidor: Data Source = DESKTOP-V89KSU6\SQLEXPRESS
            //Base De Datos: Initial Catalog = 
            //Modo Seguridad de acceso: Integrated Security = false o True (si es false, se coloca user ID y password de SQL)
            //User ID=sa
            //Password="

            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Client>().HasKey(c => new { c.IdClient });
            modelBuilder.Entity<Client>().Property(c => c.IdClient).UseIdentityColumn().Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            base.OnModelCreating(modelBuilder);

        }

        public DbSet<Client> Client { get; set; }


    }
}
