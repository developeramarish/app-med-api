﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedAPI.Domain
{
   public class Medic
    {
        public Medic()
        {
            user = new User();
        }

        public string cmp { get; set; }
        public string rne { get; set; }
        public long id { get; set; }
        public User user { get; set; }

        public string Speciality { get; set; }
    }
}
