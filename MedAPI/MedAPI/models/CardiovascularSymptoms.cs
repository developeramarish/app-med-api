﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedAPI.models
{
    public class CardiovascularSymptoms
    {
        public long id { get; set; }
        public long cardiovascularNoteId { get; set; }
        public string cardiovascularSymptoms { get; set; }
        public bool isDeleted { get; set; }
    }
}