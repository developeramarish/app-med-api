﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
    public class PatientAllergies
    {
        public long id { get; set; }
        public long patientId { get; set; }
        public string allergies { get; set; }
        public bool isDeleted { get; set; }
    }
}
