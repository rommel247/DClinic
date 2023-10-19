using AutoMapper;
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
    }
}
