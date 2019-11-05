using CitasClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasClientes.DA.Interfaces
{
    interface IPaciente
    {
        public IEnumerable<Paciente> GetPacientes();
    }
}
