﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.Cereri
{
    public class CreareCerereDto
    {
        public string Motiv { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Notite { get; set; }
        public int PersoanaId { get; set; }
     
        public string PersoanaPasword { get; set; }

    }
}
