using System;
using System.Collections.Generic;
using CitasClientes.DA;
using CitasClientes.Model;
using Microsoft.EntityFrameworkCore;

namespace CitasClientes.Repository
{
    public class CitaRepository : ICitaRepository
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

        public IEnumerable<Paciente> GetPacientes()
        {
            return context.Pacientes;
        }

        public IEnumerable<TipoCita> GetTiposCitas()
        {
            return context.TiposCitas;
        }
    }
}
