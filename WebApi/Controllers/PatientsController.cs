using Db;
using Db.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dto;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PatientsController : ControllerBase
    {
        private readonly ILogger<PatientsController> _logger;
        private readonly AGSR_Context _dbContext;

        public PatientsController(AGSR_Context dbContext, ILogger<PatientsController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Patient> GetPatients()
        {
            return this._dbContext.Patients.ToList();
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePatient([FromQuery]Int32 id)
        {
            var patient = this._dbContext.Patients.Where(e => e.Id == id).FirstOrDefault();
            if (patient == null) { return NotFound($"Patient with id {id} not found."); }
            this._dbContext.Patients.Remove(patient);
            this._dbContext.SaveChanges();
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult EditPatient([FromQuery] Int32 id, [FromBody] CreatePatientDto dto)
        {
            if (dto.Active == null || !Active.isValid(dto.Active))
            {
                return BadRequest("Active field invalid");
            }

            if (dto.Gender == null || !Gender.isValid(dto.Gender))
            {
                return BadRequest("Gender field invalid");
            }

            var patient = this._dbContext.Patients.Where(e => e.Id == id).FirstOrDefault();
            if (patient == null) { return NotFound($"Patient with id {id} not found."); }
            patient.Name = dto.Name.ToString();
            patient.Gender = dto.Gender;
            patient.Active = dto.Active;
            patient.BirthDate = dto.BirthDate;
            this._dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost]
        async public Task<ActionResult>  CreatePatient([FromBody] CreatePatientDto dto)
        {
            if (dto.Active == null || !Active.isValid(dto.Active))
            {
                return BadRequest("Active field invalid");
            }

            if (dto.Gender == null || !Gender.isValid(dto.Gender))
            {
                return BadRequest("Gender field invalid");
            }

            var patient = new Patient()
            {
               Gender = dto.Gender,
               Active = dto.Active,
               BirthDate = dto.BirthDate,
               Name = dto.Name.ToString()
            };

            _dbContext.Patients.Add(patient);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(CreatePatient), new {id = patient.Id});
        }
    }
}
