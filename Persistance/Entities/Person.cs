using System.Collections.Generic;

namespace Persistance.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public ICollection<Cerere> Cereri { get; set; }
    }
}
