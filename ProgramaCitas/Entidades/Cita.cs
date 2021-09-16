using System;
using System.ComponentModel.DataAnnotations;

namespace ProgramaCitas.Entidades
{
    public class Cita
    {
        [Key]
        public string CitaId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

    }
}
