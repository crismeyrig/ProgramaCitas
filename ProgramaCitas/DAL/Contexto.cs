using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramaCitas.Entidades;

namespace ProgramaCitas.DAL
{
    public class Contexto: DbContext
    {
        public DbSet<Citas> cita { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source=Citas.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Citas>().HasData(new Citas
            {
                CitaId = 1,
                Nombres = "Crismeyri",
                Apellidos = "Gutierrez Gil",
                Fecha = new DateTime(2021, 09, 16),
                Descripcion = " Lavado de pelo y secado normal "
            
            });

        }
    }
}