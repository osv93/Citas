using CitasClientes.DA.Interfaces;
using CitasClientes.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasClientes.DA
{
    public class CitaRepository : ICita
    {
        private readonly Context context;

        public CitaRepository(Context context)
        {
            this.context = context;
        }

        public void AddCita(Cita cita)
        {
            context.Entry(cita).State = EntityState.Added;
            context.SaveChanges();
        }

        public IEnumerable<Cita> GetCitas()
        {
            return context.Citas;
        }
    }
}
