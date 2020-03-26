using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Persons.Models;

namespace Application.Persons
{
    public interface IRepositoryPersons
    {
        Task<int> AdaugarePersoana(PersonDto person);
        Task StergerePersoana(int id);
        Task<List<PersonDto>> ExtragerePersoane();
        Task<PersonDto> ExtragerePersoana(int id);
    }
}
