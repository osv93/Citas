using System.Collections.Generic;
using CitasClientes.Model;
using CitasClientes.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CitasClientes.Entities;

namespace CitasClientes.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class CitasController : ControllerBase
    {
        private readonly ICitaRepository citaRepository = null;

        public CitasController(ICitaRepository _citaRepository)
        {
            citaRepository = _citaRepository;
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
        public void CancelCita(int citaID)
        {
            citaRepository.CancelCita(citaID);
        }
    }
}
