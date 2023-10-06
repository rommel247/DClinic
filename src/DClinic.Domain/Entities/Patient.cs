using System;
using System.Collections.Generic;

namespace DClinic.Domain.Entities;

    public partial class Patient
    {
        public int Id { get; set; }

        public string Fname { get; set; }

        public string Mname { get; set; }

        public string Lname { get; set; }

        public DateTime BirthDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual ICollection<PatientLog> PatientLogs { get; set; } = new List<PatientLog>();
    }