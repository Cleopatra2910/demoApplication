using System;

namespace Application.Cereri.Models
{
    public class CerereDto
    {
        public int Id { get; set; }
        public string Motiv { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Notite { get; set; }
        public int PersoanaId { get; set; }
        public int StatusCerereId { get; set; }
        public int StatusCerereName { get; set; }
    }
}
