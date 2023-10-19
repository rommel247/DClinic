using AutoMapper;
using DClinic.Domain.Dtos;
using DClinic.Domain.Entities;
using DClinic.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DClinic.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IGenericRepository<Patient> _repository;
        private readonly IMapper _mapper;
        //TODO add mapper here and do the mapper prrofile
        public PatientService(
            IGenericRepository<Patient> repository,
            IMapper mapper
            )
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> AddPatientAsync(PatientDto patientDto)
        {
            //add mapper
            var patient = _mapper.Map<Patient>(patientDto);
            var result = await _repository.AddAsync(patient);
            return result.Id;
        }

        public async Task<IEnumerable<PatientDto>> GetAllPatientHistory()
        {
            var patient = await _repository.GetAllAsync();
           return _mapper.Map<IEnumerable<PatientDto>>(patient);
        }

        public async Task<IEnumerable<PatientDto>> GetByNameAsync(string name)
        {
            var patientEntity = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<PatientDto>>(patientEntity);
        }

        public async Task<PatientDto> GetPatientByIdAsync(int id)
        {
            var patientResult = await _repository.GetbyIdAsync(id);
            return _mapper.Map<PatientDto>(patientResult); ;
        }

        public async Task<bool> UpdatePatientAsync(PatientDto patient)
        {
           var patientEntity = _mapper.Map<Patient>(patient);
           var updatedEntity = await _repository.UpdateAsync(patientEntity);
            return (updatedEntity != null?true:false);
        }
    }
}
