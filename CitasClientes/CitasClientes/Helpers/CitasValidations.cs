using CitasClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasClientes.Helpers
{
    public class CitasValidations
    {
        private bool ValidaCancelarCitaAntesDe24Horas(Cita cita)
        {
            bool sePuedeCancelarLaCita = false;
            DateTime fechaHoraActual = DateTime.Now;
            fechaHoraActual = fechaHoraActual.AddDays(1);

            int result = DateTime.Compare(fechaHoraActual, cita.FechaCita);
            if (result <= 0){
                sePuedeCancelarLaCita = true;
            }

            return sePuedeCancelarLaCita;
        }

        private bool ValidaAgregarMasDeUnaCitaMismoDia(IEnumerable<Cita> citas, DateTime fechaProximaCita)
        {
            bool sePuedeAgregarLaCita = false;
            Cita citaEncontrada = citas.FirstOrDefault(x => x.FechaCita.Day == fechaProximaCita.Day);
            if (citaEncontrada == null)
            {
                sePuedeAgregarLaCita = true;
            }

            return sePuedeAgregarLaCita;
        }

        public bool SePuedeCancelarCita(Cita cita)
        {
            bool sePuedeCancelarLaCita = ValidaCancelarCitaAntesDe24Horas(cita);
            return sePuedeCancelarLaCita;
        }

        public bool SePuedeAgregarCita(IEnumerable<Cita> citas, DateTime fechaProximaCita)
        {
            bool sePuedeCancelarLaCita = ValidaAgregarMasDeUnaCitaMismoDia(citas, fechaProximaCita);
            return sePuedeCancelarLaCita;
        }

    }
}
