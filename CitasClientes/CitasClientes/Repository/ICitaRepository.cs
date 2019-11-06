using CitasClientes.Model;
using System.Collections.Generic;

namespace CitasClientes.Repository
{
    public interface ICitaRepository
    {
        public void AddCita(Cita cita);
        public IEnumerable<Cita> GetCitas();
        public IEnumerable<Paciente> GetPacientes();
        public IEnumerable<TipoCita> GetTiposCitas();
    }
}
