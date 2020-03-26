using System.Collections.Generic;
using Application.Cereri.Models;

namespace Application.Persons.Models
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<CerereDto> Cereri { get; set; }
    }
}
