using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Text;

namespace ProgramaCitas.Entidades
{
    public class Citas
    {
        [Key]
        public int CitaId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        public Citas()
        {
            CitaId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            Descripcion = string.Empty;
            Fecha = DateTime.Now;
          
        }

    }
}
