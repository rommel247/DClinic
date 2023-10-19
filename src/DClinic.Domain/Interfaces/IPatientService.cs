using DClinic.Domain.Commands;
using DClinic.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DClinic.Domain.Interfaces
{
    public interface IPatientService
    {
        public Task<PatientDto> GetPatientByIdAsync(int id);
        public  Task<IEnumerable<PatientDto>> GetAllPatientHistory();
        //TODO replace with Command
        public Task<int> AddPatientAsync(CreatePatientCommand patient);
        public Task<bool> UpdatePatientAsync(UpdatePatientCommand patient);
        public Task<IEnumerable<PatientDto>> GetByNameAsync(string name);

    }
}
