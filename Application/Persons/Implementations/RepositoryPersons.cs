using Application.Persons.Models;
using Persistance;
using System;
using System.Collections.Generic;
using System.Text;
using Persistance.Entities;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Persons.Implementations
{
    public class RepositoryPersons : IRepositoryPersons
    {
        private readonly AppDbContext _appDbContext;

        public RepositoryPersons(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> AdaugarePersoana(PersonDto personDto)
        {
            var newPerson = new Person
            {
                FirstName = personDto.FirstName,
                LastName = personDto.LastName,
            };

            _appDbContext.Persons.Add(newPerson);
            await _appDbContext.SaveChangesAsync();

            return newPerson.Id;
        }

        public async Task StergerePersoana(int id)
        {
            var personForDelete = _appDbContext.Persons.FirstOrDefault(x => x.Id == id);

            _appDbContext.Persons.Remove(personForDelete);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<PersonDto>> ExtragerePersoane()
        {
            //var personsFromDb = await _appDbContext.Persons.ToListAsync();

            //var personsDto = personsFromDb.Select(persoanaCurentaFromDb => new PersonDto
            //{
            //    Id = persoanaCurentaFromDb.Id,
            //    FirstName = persoanaCurentaFromDb.FirstName,
            //    LastName = persoanaCurentaFromDb.LastName
            //}).ToList();

            //return personsDto;

            return await _appDbContext.Persons
                .Select(persoanaCurentaFromDb => new PersonDto
                {
                    Id = persoanaCurentaFromDb.Id,
                    FirstName = persoanaCurentaFromDb.FirstName,
                    LastName = persoanaCurentaFromDb.LastName
                }).ToListAsync();
        }

        public async Task<PersonDto> ExtragerePersoana(int id)
        {
            var dbPerson = await _appDbContext.Persons.FirstOrDefaultAsync(x => x.Id == id);

            return new PersonDto
            {
                Id = dbPerson.Id,
                FirstName = dbPerson.FirstName,
                LastName = dbPerson.LastName
            };
        }
    }
}
