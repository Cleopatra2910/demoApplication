using DataTransferObjects.Persons;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Application.Persons
{
    public interface IRepositoryPersons
    {
        Task<int> AdaugarePersoana(PersonForCreateDto person);
        Task StergerePersoana(PersonForDeleteDto person);
        Task<List<PersonDto>> ExtragerePersoaneForAdmin(GetPersonsForAdminDto data);
        Task<PersonDto> ExtragerePersoana(GetPersonByIdDto data);
        Task<List<PersonDropdownDto>> ExtragerDropdown();
    }
}
