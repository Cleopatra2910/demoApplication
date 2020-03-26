using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Cereri;
using DataTransferObjects.Cereri;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoRealApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CerereController : ControllerBase
    {
        private readonly IRepositoryCereri _repositoryCerere;

        public CerereController(IRepositoryCereri repository)
        {
            _repositoryCerere = repository;
        }

        [HttpPost]
        public async Task<int> AddCrere([FromBody] CreareCerereDto cerere)
        {
            return await _repositoryCerere.CreareCerere(cerere);
        }

        [HttpPatch]
        public async Task<int> EditCrere([FromBody] EditareCerereDto cerere)
        {
            return await _repositoryCerere.EditareCerere(cerere);
        }

        [HttpGet("getByStatus")]
        public async Task<List<CerereForGet>> GetByStatus([FromQuery] DataForGetCereriByStatus data)
        {
            return await _repositoryCerere.GetCerereByStatus(data);
        }

        [HttpGet("getMyCereri")]
        public async Task<List<CerereForGet>> GetCereriByUser([FromQuery] DataForgetMyCereri data)
        {
            return await _repositoryCerere.GetMyCereri(data);
        }

        [HttpPatch("accept-decline")]
        public async Task<int> AcceptOrDecline([FromQuery] AcceptOrDeclineDataDto data)
        {
            return await _repositoryCerere.AcceptOrDeclineCerere(data);
        }
    }
}