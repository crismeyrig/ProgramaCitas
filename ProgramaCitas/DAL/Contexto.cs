using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramaCitas.Entidades;
using ProgramaCitas.UI.Registros;


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