using System;
using System.ComponentModel.DataAnnotations;
namespace ProgramaCitas.Entidades
{
    public class Cita
    {
        [Key]
        public int UsuarioId { get; set; }
        public string CitaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Telefono { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

    }
}
