using DClinic.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DClinic.Domain.Commands
{
    //TODO add fluent validation
    public abstract class PatientCommand
    {      
        public string Fname { get; set; }

        public string Mname { get; set; }

        public string Lname { get; set; }

        public DateTime BirthDate { get; set; }
    
    }
    public class CreatePatientCommand: PatientCommand
    {
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        //public virtual ICollection<PatientLogDto> PatientLogs { get; set; } = new List<PatientLogDto>();
    }
    public class UpdatePatientCommand : PatientCommand
    {
        public int Id { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
