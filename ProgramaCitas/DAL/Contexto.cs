using Microsoft.EntityFrameworkCore;
using ProgramaCitas.Entidades;
using System;

namespace ProgramaCitas.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Citas> Citas{ get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source = Citas.db");
        }
    }
}