using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;

namespace ProEventos.Persistence.Contracts
{
    public class BatchPersistence : IBatchPersistence
    {
        private readonly ProEventosContext _context;
        public BatchPersistence(ProEventosContext context)
        {
            _context = context;
        }

        public async Task<Batch> GetBatchByEventIdAsync(int eventId, int id)
        {
            IQueryable<Batch> query = _context.Batches;

            query = query.AsNoTracking()
                         .Where(lote => lote.EventId == eventId
                                     && lote.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Batch[]> GetBatchesByEventsIdAsync(int eventId)
        {
            IQueryable<Batch> query = _context.Batches;

            query = query.AsNoTracking()
                         .Where(lote => lote.EventId == eventId);

            return await query.ToArrayAsync();
        }


    }
}