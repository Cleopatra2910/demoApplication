using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.Cereri
{
    public class AcceptOrDeclineDataDto
    {
        public int CerereId { get; set; }
        public string AdminPassword { get; set; }
        public int StatusCerere { get; set; }
    }
}
