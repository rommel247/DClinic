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
        public Task<PatientDto> GetPatientById(int id);
        public  Task<IEnumerable<PatientDto>> GetAllPatientHistory();
        //TODO replace with Command
        public Task<int> AddPatient(PatientDto patient);

        public Task UpdatePatient(PatientDto patient);
        public Task<IEnumerable<PatientDto>> GetByName(string name);

    }
}
