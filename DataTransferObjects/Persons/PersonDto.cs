using System.Collections.Generic;
using DataTransferObjects.Cereri;

namespace DataTransferObjects.Persons
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }

        //public List<CerereDto> Cereri { get; set; }
    }
}
