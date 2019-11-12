using CitasClientes.Helpers;
using CitasClientes.Model;
using System;
using Xunit;

namespace XUnitTestProject1
{
    public class CitasValidations_CancelarCita_Tests
    {
        private readonly CitasValidations validaciones;
        private readonly Paciente paciente;
        private readonly TipoCita tipoCita;
        private readonly Cita cita;

        public CitasValidations_CancelarCita_Tests() {
            validaciones = new CitasValidations();

            paciente = new Paciente { PacienteID = "1111", PacienteFullName = "Luis Osvaldo Aguero Perez" };
            tipoCita = new TipoCita { TipoCitaID = 1, TipoCitaNombre = "Odontología" };
            cita = new Cita { CitaID = 1, FechaCita = DateTime.Now, Activa = true, 
                              Paciente = paciente, TipoCita = tipoCita };
        }

        [Fact]
        public void SePuedeCancelarCita_HoraDeLaCitaConMenos24HorasDeAntelacion_RetornaFalse()
        {
            cita.FechaCita = DateTime.Now.AddHours(5);
            bool valorObtenido = validaciones.SePuedeCancelarCita(cita);

            Assert.False(valorObtenido);
        }

        [Fact]
        public void SePuedeCancelarCita_HoraDeLaCitaConMas24HorasDeAntelacion_RetornaTrue()
        {
            cita.FechaCita = DateTime.Now.AddDays(2);
            bool valorObtenido = validaciones.SePuedeCancelarCita(cita);

            Assert.True(valorObtenido);
        }
    }
}
