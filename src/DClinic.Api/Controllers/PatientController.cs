using AutoMapper;
using DClinic.Domain.Commands;
using DClinic.Domain.Dtos;
using DClinic.Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DClinic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;
        private readonly IMapper _mapper;
        public PatientController(IPatientService patientService,IMapper mapper)
        {
            _patientService = patientService;   
            _mapper = mapper;
        }

        [HttpGet,Route("GetById")]
        public async Task<PatientDto> GetById(int id)
        {
            var result = await _patientService.GetPatientByIdAsync(id);
            return result;
        }        

        [HttpGet,Route("GetAll")]
        public async Task<IEnumerable<PatientDto>> GetAll()
        {
            var result = await _patientService.GetAllPatientHistory();
            return result;
        }

        [HttpGet, Route("GetByName")]
        public async Task<IEnumerable<PatientDto>> GetByName(string name)
        {
            var result = await _patientService.GetByNameAsync(name);
            return result ?? Enumerable.Empty<PatientDto>();
        }
        
        //TODO add Response Type here 
        //TODO add Redis cache here
        [HttpPost]
        public async Task<int> AddPatient([FromBody] CreatePatientCommand command )
        {
            var result = await _patientService.AddPatientAsync(command);
            return result;
        }

    }
}
