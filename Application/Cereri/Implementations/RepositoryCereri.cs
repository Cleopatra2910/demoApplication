using System;
using System.Collections.Generic;
using System.Text;
using Application.Cereri.Models;
using Application.Enums;
using Persistance;
using Persistance.Entities;

namespace Application.Cereri.Implementations
{
    public class RepositoryCereri : IRepositoryCereri
    {
        private readonly AppDbContext _appDbContext;

        public RepositoryCereri(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddCererenoua(CerereDto dto)
        {
            var newCerere = new Cerere
            {
                PersoanaId = dto.Id,
                FromDate = dto.ToDate,
                StatusCerere = (int)StatusCerereEnum.New
            };

            var newCerere1 = new Cerere
            {
                PersoanaId = dto.Id,
                FromDate = dto.ToDate,
                StatusCerere = 0
            };

            //var dtoNew = new CerereDto
            //{
            //    StatusCerereName = StatusCerereEnum.Approved.ToString()
            //}
            //var approvedId
        }
    }
}
