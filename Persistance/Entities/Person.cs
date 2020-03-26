using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public ICollection<Cerere> Cereri { get; set; }
    }
}
