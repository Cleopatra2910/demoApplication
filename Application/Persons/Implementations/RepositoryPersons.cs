using Microsoft.EntityFrameworkCore;
using Persistance;
using Persistance.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataTransferObjects.Persons;

namespace Application.Persons.Implementations
{
    public class RepositoryPersons : IRepositoryPersons
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public RepositoryPersons(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        private bool IsAdmin(string password)
        {
            var result = _appDbContext.Persons.Any(x => x.IsAdmin == true && x.Password ==password);

            return result;
        }

        public async Task<int> AdaugarePersoana(PersonForCreateDto personDto)
        {
            var checkIfIsAdmin = IsAdmin(personDto.AdminPassword);

            if (checkIfIsAdmin == true)
            {
                var newPerson = _mapper.Map<Person>(personDto);

                _appDbContext.Persons.Add(newPerson);
                await _appDbContext.SaveChangesAsync();

                return newPerson.Id;
            }

            return 0;
        }

        public async Task StergerePersoana(PersonForDeleteDto personDto)
        {
            var checkIfIsAdmin = IsAdmin(personDto.AdminPassword);

            if (checkIfIsAdmin)
            {
                var personForDelete = _appDbContext.Persons.FirstOrDefault(x => x.Id == personDto.Id);

                _appDbContext.Persons.Remove(personForDelete);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<PersonDto>> ExtragerePersoaneForAdmin(GetPersonsForAdminDto data)
        {
            var checkIfIsAdmin = IsAdmin(data.AdminPassword);

            if (checkIfIsAdmin)
            {
                return await _appDbContext.Persons
                    .Select(x => _mapper.Map<PersonDto>(x)).ToListAsync();
            }

            return new List<PersonDto>();
        }

        public async Task<PersonDto> ExtragerePersoana(GetPersonByIdDto getById)
        {
            var checkIfIsAdmini = IsAdmin(getById.AdminPassword);

            if (checkIfIsAdmini)
            {
                var dbPerson = await _appDbContext.Persons.FirstOrDefaultAsync(x => x.Id == getById.Id);

                return _mapper.Map<PersonDto>(dbPerson);
            }

            return new PersonDto();
        }

        public async Task<List<PersonDropdownDto>> ExtragerDropdown()
        {
            return await _appDbContext.Persons
                .Select(x => _mapper.Map<PersonDropdownDto>(x)).ToListAsync();
        }
    }
}
