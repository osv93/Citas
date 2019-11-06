using CitasClientes.DA.Interfaces;
using CitasClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasClientes.DA
{
    public class PacienteRepository : IPaciente
    {
        private readonly Context context;

        public PacienteRepository(Context context)
        {
            this.context = context;
        }

        public IEnumerable<Paciente> GetPacientes()
        {
            return context.Pacientes;
        }
    }
}
