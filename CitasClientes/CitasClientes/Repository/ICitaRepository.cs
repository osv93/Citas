using CitasClientes.Model;
using System.Collections.Generic;

namespace CitasClientes.Repository
{
    public interface ICitaRepository
    {
        public void AddCita(Cita cita);
        public void CancelCita(int citaID);
        public Cita GetCitaById(int citaID);
        public IEnumerable<Cita> GetCitasByPacienteID(string pacienteID);
        public IEnumerable<Cita> GetCitas();
        public IEnumerable<Paciente> GetPacientes();
        public IEnumerable<TipoCita> GetTiposCitas();
    }
}
