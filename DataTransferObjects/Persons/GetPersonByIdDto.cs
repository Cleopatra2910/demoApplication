using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferObjects.Persons
{
    public class GetPersonByIdDto
    {
        public int Id { get; set; }
        public string AdminPassword { get; set; }
    }
}
