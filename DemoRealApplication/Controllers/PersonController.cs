using Application.Persons;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataTransferObjects.Persons;

namespace DemoRealApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IRepositoryPersons _repositoryPersons;

        #region Person For Admin

        public PersonController(IRepositoryPersons repositoryPersons)
        {
            _repositoryPersons = repositoryPersons;
        }

        [HttpPost]
        public async Task<int> AddPerson([FromBody] PersonForCreateDto person)
        {
            return await _repositoryPersons.AdaugarePersoana(person);
        }

        [HttpDelete]
        public async Task DeletePerson([FromQuery] PersonForDeleteDto person)
        {
            await _repositoryPersons.StergerePersoana(person);
        }

        [HttpGet("getAll")]
        public async Task<List<PersonDto>> GetPersons([FromQuery] GetPersonsForAdminDto data)
        {
            return await _repositoryPersons.ExtragerePersoaneForAdmin(data);
        }

        [HttpGet]
        public async Task<PersonDto> GetPerson([FromQuery] GetPersonByIdDto data)
        {
            return await _repositoryPersons.ExtragerePersoana(data);
        }

        #endregion

        #region Person For Users

        [HttpGet("person-dropdown")]
        public async Task<List<PersonDropdownDto>> GetPersonsDropdown()
        {
            return await _repositoryPersons.ExtragerDropdown();
        }

        #endregion
    }
}