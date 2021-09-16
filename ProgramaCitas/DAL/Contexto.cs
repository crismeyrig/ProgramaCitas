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
            optionsBuilder.UseSqlite(@"Data Source = Data\citas.db");
        }
    }
}
