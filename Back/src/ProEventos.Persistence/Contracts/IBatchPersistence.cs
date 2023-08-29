using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contracts
{
    public interface IBatchPersistence
    {
        Task<Batch[]> GetBatchesByEventsIdAsync(int eventId);

        Task<Batch> GetBatchByEventIdAsync(int eventId, int id);
    }
}