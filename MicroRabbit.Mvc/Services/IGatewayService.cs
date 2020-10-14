using System.Collections.Generic;
using System.Threading.Tasks;
using MicroRabbit.Mvc.Models.Dto;

namespace MicroRabbit.Mvc.Services
{
    public interface IGatewayService
    {
        Task Transfer(TransferDto dto);

        Task<IEnumerable<TransferLogDto>> GetLogs();
    }
}