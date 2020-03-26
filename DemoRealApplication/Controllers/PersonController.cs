using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Persons;
using Application.Persons.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoRealApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IRepositoryPersons _repositoryPersons;

        public PersonController(IRepositoryPersons repositoryPersons)
        {
            _repositoryPersons = repositoryPersons;
        }

        [HttpPost]
        public async Task<int> AddPerson([FromBody] PersonDto person)
        {
            return await _repositoryPersons.AdaugarePersoana(person);
        }

        [HttpDelete("{id}")]
        public async Task DeletePerson([FromRoute] int  id)
        {
            await _repositoryPersons.StergerePersoana(id);
        }

        [HttpGet]
        public async Task<List<PersonDto>> GetPersons()
        {
            return await _repositoryPersons.ExtragerePersoane();
        }

        [HttpGet("{id}")]
        public async Task<PersonDto> GetPerson([FromRoute] int id)
        {
            return await _repositoryPersons.ExtragerePersoana(id);
        }
    }
}