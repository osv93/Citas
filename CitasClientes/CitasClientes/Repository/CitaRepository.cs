using System;
using System.Collections.Generic;
using System.Linq;
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

        public void CancelCita(int citaID)
        {
            var cita = context.Citas.FirstOrDefault(item => item.CitaID == citaID);
            if (cita != null)
            {
                context.Citas.Attach(cita);

                cita.Activa = false;
                context.Entry(cita).Property(x => x.Activa).IsModified = true;
                context.SaveChanges();
            }
        }

        public Cita GetCitaById(int citaID)
        {
            var cita = context.Citas.FirstOrDefault(item => item.CitaID == citaID && item.Activa == true);
            return cita;
        }

        public IEnumerable<Cita> GetCitas()
        {
            return context.Citas;
        }

        public IEnumerable<Cita> GetCitasByPacienteID(string pacienteID)
        {
            return context.Citas.Include(TipoCita => TipoCita.TipoCita).Include(Paciente=> Paciente.Paciente)
                                .Where(x => x.Paciente.PacienteID == pacienteID)
                                .ToList();
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
