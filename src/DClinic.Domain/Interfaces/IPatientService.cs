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
        public Task<int> AddPatientAsync(PatientDto patient);

        public Task<bool> UpdatePatientAsync(PatientDto patient);
        public Task<IEnumerable<PatientDto>> GetByNameAsync(string name);

    }
}
