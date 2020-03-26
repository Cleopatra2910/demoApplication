using Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.Cereri
{
    public class CerereForGet
    {
        public int Id { get; set; }
        public string Motiv { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Notite { get; set; }

        //asa se specifica relatia dintre tabela 
        public Person Persoana { get; set; }
        public int PersoanaId { get; set; }

        public int StatusCerere { get; set; }
    }
}
