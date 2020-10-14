using System.Collections.Generic;
using MicroRabbit.Transfer.Data.Context;
using MicroRabbit.Transfer.Domain.Interfaces;
using MicroRabbit.Transfer.Domain.Models;

namespace MicroRabbit.Transfer.Data.Repository
{
    public class TransferRepository : ITransferRepository
    {
        private TransferDbContext context;

        public TransferRepository(TransferDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<TransferLog> GetTransferLogs()
        {
            return context.TransferLogs;
        }

        public void Add(TransferLog model)
        {
            context.TransferLogs.Add(model);
            context.SaveChanges();
        }
    }
}