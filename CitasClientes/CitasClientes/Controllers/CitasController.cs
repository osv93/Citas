using System.Collections.Generic;
using CitasClientes.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CitasClientes.Entities;
using CitasClientes.Helpers;
using CitasClientes.Contratos;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;

namespace CitasClientes.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class CitasController : ControllerBase
    {

        private IRepositoryWrapper _repoWrapper;
        private readonly CitasValidations citaValidacion = null;

        private readonly ILogger<CitasController> _logger;

        public CitasController(IRepositoryWrapper repoWrapper,
                               ILogger<CitasController> logger)
        {
            _repoWrapper = repoWrapper;
            _logger = logger;
            citaValidacion = new CitasValidations();
        }

        [Authorize(Roles = Role.Admin)]
        [HttpGet]
        public async Task<IActionResult> GetCitas()
        {
            _logger.LogInformation("Fetching all the Students from the storage");

            IEnumerable<Cita> citas = await _repoWrapper.CitaRepo.GetAll();
            return Ok(citas);
            throw new Exception("Exception while fetching all the Citas from the storage.");
        }

        [HttpGet]
        public async Task<IActionResult> GetTiposCitas()
        {

            IEnumerable<TipoCita> tiposCitas = await _repoWrapper.TipoCitaRepo.GetAll();
            return Ok(tiposCitas);
            throw new Exception("Exception while fetching all the TiposCitas from the storage.");
        }

        [HttpGet("{pacienteID}")]
        public async Task<IActionResult> GetCitasByPacienteId(string pacienteID)
        {

            IEnumerable<Cita> citas =
                await _repoWrapper.CitaRepo.FindByCondition(predicate: x => x.Paciente.PacienteID == pacienteID && x.Activa == true,
                                                            orderBy: null,
                                                            take: null,
                                                            include: source => source.Include(a => a.TipoCita).Include(a => a.Paciente));

            return Ok(citas);
            throw new Exception("Exception while fetching GetCitasByPacienteId from the storage.");
        }

        [HttpPost]
        public async Task<IActionResult> AddCita([FromBody]Cita cita)
        {
            IEnumerable<Cita> citas =
                await _repoWrapper.CitaRepo.FindByCondition(predicate: x => x.Paciente.PacienteID == cita.Paciente.PacienteID && x.Activa == true,
                                                orderBy: null,
                                                take: null,
                                                include: source => source.Include(a => a.TipoCita).Include(a => a.Paciente));

            bool sePuedeAgregarLaCita = citaValidacion.SePuedeAgregarCita(citas, cita.FechaCita);
            if (sePuedeAgregarLaCita)
            {
                await _repoWrapper.CitaRepo.Add(cita);
                await _repoWrapper.Save();
                return NoContent();
            }
            else
            {
                throw new Exception("No se puede crear una cita para el mismo día.");
            }
        }

        [HttpPut("{citaID}")]
        public async Task<IActionResult> CancelCita(int citaID)
        {
            Cita cita = await _repoWrapper.CitaRepo.GetById(citaID);
            if (cita != null)
            {
                bool sePuedeCancelar = citaValidacion.SePuedeCancelarCita(cita);
                if (sePuedeCancelar)
                {
                    cita.Activa = false;
                    _repoWrapper.CitaRepo.Update(cita);
                    await _repoWrapper.Save();
                    return Ok();
                }
                else
                {
                    throw new Exception("Las citas se deben cancelar con mínimo 24 horas de antelación.");
                }
            }
            else
            {
                throw new Exception("La cita no existe.");
            }
        }
        //[HttpPut("{id}")]
        //public IActionResult UpdateOwner(Guid id, [FromBody]OwnerForUpdateDto owner)
        //{
        //    try
        //    {
        //        if (owner == null)
        //        {
        //            _logger.LogError("Owner object sent from client is null.");
        //            return BadRequest("Owner object is null");
        //        }

        //        if (!ModelState.IsValid)
        //        {
        //            _logger.LogError("Invalid owner object sent from client.");
        //            return BadRequest("Invalid model object");
        //        }

        //        var ownerEntity = _repository.Owner.GetOwnerById(id);
        //        if (ownerEntity == null)
        //        {
        //            _logger.LogError($"Owner with id: {id}, hasn't been found in db.");
        //            return NotFound();
        //        }

        //        _mapper.Map(owner, ownerEntity);

        //        _repository.Owner.UpdateOwner(ownerEntity);
        //        _repository.Save();

        //        return NoContent();
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Something went wrong inside UpdateOwner action: {ex.Message}");
        //        return StatusCode(500, "Internal server error");
        //    }
        //}
    }
}
