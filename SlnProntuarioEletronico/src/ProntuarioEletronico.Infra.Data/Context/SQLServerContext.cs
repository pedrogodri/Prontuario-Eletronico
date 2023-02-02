using Microsoft.EntityFrameworkCore;
using ProntuarioEletronico.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProntuarioEletronico.Infra.Data.Context
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext(DbContextOptions<SQLServerContext> options) 
            : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalPlan>()
            .HasData(
                    new { Id = 1, Plan = "Unimed"},
                    new { Id = 2, Plan = "SulAmérica" },
                    new { Id = 3, Plan = "Allianz" },
                    new { Id = 4, Plan = "BlueMed" }
                );
        }

        #region DbSets<Tables>
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients  { get; set; }
        public DbSet<MedicalPlan> MedicalPlans { get; set; }
        #endregion
    }
}
