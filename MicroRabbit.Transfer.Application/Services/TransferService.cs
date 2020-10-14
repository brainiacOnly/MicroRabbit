using System.Collections.Generic;
using MicroRabbit.Domain.Core.Bus;
using MicroRabbit.Transfer.Application.Interfaces;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Application.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository transferLogRepository;
        private readonly IEventBus eventBus;

        public TransferService(ITransferRepository transferLogRepository, IEventBus eventBus)
        {
            this.transferLogRepository = transferLogRepository;
            this.eventBus = eventBus;
        }
        
        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return transferLogRepository.GetTransferLogs();
        }
    }
}