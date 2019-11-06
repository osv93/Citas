using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CitasClientes.Model
{
    public class Cita
    {
        [Key]
        public int CitaID { get; set; }

        [Required]
        public Paciente Paciente { get; set; }

        [Required]
        public TipoCita TipoCita { get; set; }

        [Required]
        public DateTime FechaCita { get; set; }
    }
}
