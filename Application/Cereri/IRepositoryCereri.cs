using System.Collections.Generic;
using System.Threading.Tasks;
using DataTransferObjects.Cereri;

namespace Application.Cereri
{
    public interface IRepositoryCereri
    {
        Task<int> CreareCerere(CreareCerereDto data);
        Task<int> EditareCerere(EditareCerereDto data);
        Task<List<CerereForGet>> GetCerereByStatus(DataForGetCereriByStatus data);
        Task<List<CerereForGet>> GetMyCereri(DataForgetMyCereri data);
        Task<int> AcceptOrDeclineCerere(AcceptOrDeclineDataDto data);
    }
}
