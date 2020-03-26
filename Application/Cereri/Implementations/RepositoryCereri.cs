using System.Collections.Generic;
using System.Linq;
using Application.Enums;
using AutoMapper;
using DataTransferObjects.Cereri;
using Persistance;
using Persistance.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Cereri.Implementations
{
    public class RepositoryCereri : IRepositoryCereri
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public RepositoryCereri(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        private bool IsAdmin(string password)
        {
            var result = _appDbContext.Persons.Any(x => x.IsAdmin == true && x.Password == password);

            return result;
        }

        private async Task<bool> IsCorrectPassword(int id, string password)
        {
            var person = await _appDbContext.Persons.FirstOrDefaultAsync(x => x.Id == id && x.Password == password);
            
            return  person != null;
        }

        private async Task<bool> IsCorrectPasswordByCerere(int idCerere, string password)
        {
            var dbCerere = _appDbContext.Cereri
                .Include(x=>x.Persoana)// include, gud shtuka
                .FirstOrDefault(x => x.Id == idCerere);

            var dbCerere1 = _appDbContext.Cereri
                .FirstOrDefault(x => x.Id == idCerere);

            if (dbCerere!=null)
            {
                var dbPerson = dbCerere.Persoana;
                if (dbPerson.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<int> CreareCerere(CreareCerereDto data)
        {
            if (await IsCorrectPassword(data.PersoanaId,data.PersoanaPasword))
            {
                var newCerere = _mapper.Map<Cerere>(data);
                _appDbContext.Cereri.Add(newCerere);
                _appDbContext.SaveChanges();

                return newCerere.Id;
            }

            return 0;
        }

        public async Task<int> EditareCerere(EditareCerereDto data)
        {
            if (await IsCorrectPasswordByCerere(data.Id, data.PersoanaPasword))
            {
                var dbCerere = _appDbContext.Cereri.FirstOrDefault(x => x.Id == data.Id);
                _mapper.Map(data, dbCerere);
                _appDbContext.SaveChanges();

                return dbCerere.Id;
            }

            return 0;
        }

        public async Task<List<CerereForGet>> GetCerereByStatus(DataForGetCereriByStatus data)
        {
            if (IsAdmin(data.AdminPassword))
            {
                return await _appDbContext.Cereri
                    .Where(x => x.StatusCerere == data.StatusCerere)
                    .Select(x => _mapper.Map<CerereForGet>(x)).ToListAsync();
            }

            return new List<CerereForGet>();
        }

        public async Task<List<CerereForGet>> GetMyCereri(DataForgetMyCereri data)
        {
            if (await IsCorrectPassword(data.UserId, data.Password))
            {
                var t = _appDbContext.Cereri
                    .Where(x => x.PersoanaId == data.UserId)
                    .Select(x => _mapper.Map<CerereForGet>(x)).ToList();

                return t;
            }

            return new List<CerereForGet>();
        }

        public async Task<int> AcceptOrDeclineCerere(AcceptOrDeclineDataDto data)
        {
            if (IsAdmin(data.AdminPassword))
            {
                var dbCerere = await _appDbContext.Cereri.FirstOrDefaultAsync(x => x.Id == data.CerereId);

                if (dbCerere!=null)
                {
                    dbCerere.StatusCerere = data.StatusCerere;
                }
                _appDbContext.SaveChanges();
                
                return dbCerere.Id;
            }

            return 0;
        }
    }
}
