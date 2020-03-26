namespace DataTransferObjects.Persons
{
    public class PersonForCreateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserPassword { get; set; }

        public string AdminPassword { get; set; }
    }
}
