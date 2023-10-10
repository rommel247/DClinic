using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DClinic.Domain.Dtos
{
    public class ReasonDto
    {
        public int Id { get; set; }

        public string ReasonCode { get; set; }

        public string ReasonShortName { get; set; }

        public string ReasonDescription { get; set; }
    }
}
