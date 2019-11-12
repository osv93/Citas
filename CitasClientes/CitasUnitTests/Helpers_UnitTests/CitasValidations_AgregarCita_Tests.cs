using CitasClientes.Helpers;
using CitasClientes.Model;
using System;
using System.Collections.Generic;
using Xunit;

namespace CitasUnitTests.Helpers_UnitTests
{
    public class CitasValidations_AgregarCita_Tests
    {
        private readonly CitasValidations validaciones;
        private readonly Paciente paciente;
        private readonly TipoCita tipoCita;
        private readonly Cita citaNueva;
        private readonly IList<Cita> citasGuardadas;

        public CitasValidations_AgregarCita_Tests()
        {
            validaciones = new CitasValidations();

            paciente = new Paciente { PacienteID = "1111", PacienteFullName = "Luis Osvaldo Aguero Perez" };
            tipoCita = new TipoCita { TipoCitaID = 1, TipoCitaNombre = "Odontología" };
            citaNueva = new Cita
            {
                FechaCita = DateTime.Now,
                Paciente = paciente,
                TipoCita = tipoCita
            };

            citasGuardadas= new List<Cita>(){
                new Cita {
                    CitaID = 1,
                    FechaCita = DateTime.Now,
                    Activa = true,
                    Paciente = paciente,
                    TipoCita = tipoCita
                }
            };
        }

        [Fact]
        public void SePuedeAgregarCita_AgregarMasDeUnaCitaMismoDia_RetornaFalse()
        {
            bool valorObtenido = validaciones.SePuedeAgregarCita(citasGuardadas, citaNueva.FechaCita);

            Assert.False(valorObtenido);
        }

        [Fact]
        public void SePuedeAgregarCita_AgregarUnaCitaUnDia_RetornaTrue()
        {
            bool valorObtenido = validaciones.SePuedeAgregarCita(new List<Cita>(), citaNueva.FechaCita );

            Assert.True(valorObtenido);
        }
    }
}
