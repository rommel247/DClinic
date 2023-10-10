using DClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DClinic.Domain.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }

        public string Fname { get; set; }

        public string Mname { get; set; }

        public string Lname { get; set; }       

        public virtual ICollection<PatientLogDto> PatientLogs { get; set; } = new List<PatientLogDto>();

    }
}
