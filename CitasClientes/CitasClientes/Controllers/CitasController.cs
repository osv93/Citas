using System.Collections.Generic;
using CitasClientes.Model;
using CitasClientes.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CitasClientes.Entities;
using CitasClientes.Helpers;

namespace CitasClientes.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class CitasController : ControllerBase
    {
        private readonly ICitaRepository citaRepository = null;
        private readonly CitasValidations citaValidacion = null;

        public CitasController(ICitaRepository _citaRepository)
        {
            citaRepository = _citaRepository;
            citaValidacion = new CitasValidations();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public IEnumerable<Cita> GetCitas()
        {
            var citas = citaRepository.GetCitas();

            return citas;
        }

        [HttpPost]
        public void AddCita(Cita cita)
        {
           citaRepository.AddCita(cita);
        }

        [HttpPut("{citaID}")]
        public IActionResult CancelCita(int citaID)
        {
            Cita cita = citaRepository.GetCitaById(citaID);
            if (cita != null)
            {
                bool sePuedeCancelar = citaValidacion.SePuedeCancelarCita(cita);
                if (sePuedeCancelar)
                {
                    citaRepository.CancelCita(citaID);
                    return BadRequest(new { message = "Cita cancelada con éxito" });
                }
            }
            else {
                return BadRequest(new { message = "La cita no existe" }); 
            }
            
            return BadRequest(new { message = "Las citas se deben cancelar con mínimo 24 horas de antelación" });
        }
    }
}
