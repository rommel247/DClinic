using AutoMapper;
using DClinic.Domain.Dtos;
using DClinic.Domain.Entities;
using DClinic.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DClinic.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IGenericRepository<Patient> _repository;
        private readonly IMapper _mapper;
        //TODO add mapper here and do the mapper prrofile
        public PatientService(IGenericRepository<Patient> repository)
        {
            _repository = repository;
        }

        public async Task<int> AddPatient(PatientDto patient)
        {
            //var patient = 
            var result = await _repository.AddAsync();
            return result.Id;
        }

        public Task<IEnumerable<PatientDto>> GetAllPatientHistory()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PatientDto>> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<PatientDto> GetPatientById(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePatient(PatientDto patient)
        {
            throw new NotImplementedException();
        }
    }
}
