using System.Collections.Generic;
using CitasClientes.DA;
using CitasClientes.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CitasClientes.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CitasController : ControllerBase
    {
        private readonly ILogger<CitasController> _logger;

        public CitasController(ILogger<CitasController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Cita> GetCitas()
        {
            Context context = new Context();

            CitaRepository citaRepo = new CitaRepository(context);
            var citas = citaRepo.GetCitas();

            return citas;
        }

        //[HttpGet]
        //public IEnumerable<Paciente> GetPacientes()
        //{
        //    Context context = new Context();

        //    CitaRepository citaRepo = new CitaRepository(context);
        //    PacienteRepository pacienteRepo = new PacienteRepository(context);
        //    var pacientes = pacienteRepo.GetPacientes();

        //    return pacientes;
        //}

        [HttpPost]
        public void AddCita(Cita cita)
        {
            Context context = new Context();

            CitaRepository citaRepo = new CitaRepository(context);
            citaRepo.AddCita(cita);
        }
    }
}
