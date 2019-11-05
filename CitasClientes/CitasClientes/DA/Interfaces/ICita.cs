using CitasClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasClientes.DA.Interfaces
{
    interface ICita
    {
        public void AddCita(Cita cita);
        public IEnumerable<Cita> GetCitas();
    }
}
