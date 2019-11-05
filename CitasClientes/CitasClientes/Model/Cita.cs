using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasClientes.Model
{
    public class Cita
    {
        public int CitaID { get; set; }
        public Paciente Paciente { get; set; }
        public TipoCita TipoCita { get; set; }
        public DateTime FechaCita { get; set; }
    }
}
