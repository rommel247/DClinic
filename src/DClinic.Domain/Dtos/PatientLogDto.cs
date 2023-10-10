using DClinic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DClinic.Domain.Dtos
{
    public class PatientLogDto
    {
        public int Id { get; set; }       

        public int? ReasonId { get; set; }

        public string Comments { get; set; }

        public virtual PatientDto Patient { get; set; }

        public virtual ReasonDto Reason { get; set; }

    }
}
