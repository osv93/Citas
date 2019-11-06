﻿using System.Collections.Generic;
using CitasClientes.Model;
using CitasClientes.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
    }
}