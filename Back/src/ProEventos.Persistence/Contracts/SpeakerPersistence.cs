using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;

namespace ProEventos.Persistence.Contracts
{
    public class SpeakerPersistence : ISpeakerPersistence
    {
        private readonly ProEventosContext _context;
        public SpeakerPersistence(ProEventosContext context)
        {
            _context = context;
        }

        #region Speaker
        public async Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents = false)
        {
            IQueryable<Speaker> query = _context.Speakers
                                                .AsNoTracking()
                                                .Include(s => s.SocialNetworks);

            if (includeEvents)
            {
                query = query.Include(s => s.EventSpeakers)
                             .ThenInclude(e => e.Event);
            }

            query = query.OrderBy(s => s.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Speaker> GetSpeakerByNameAsync(string name, bool includeEvents)
        {
            IQueryable<Speaker> query = _context.Speakers
                                                .AsNoTracking()
                                                .Include(s => s.SocialNetworks);

            if (includeEvents)
            {
                query = query.Include(s => s.EventSpeakers)
                             .ThenInclude(e => e.Event);
            }

            query = query.OrderBy(e => e.Id)
                         .Where(s => s.Name.ToLower()
                                           .Contains(name.ToLower()));

            return query.FirstOrDefault();
        }

        public async Task<Speaker> GetSpeakerByIdAsync(int id, bool includeEvents)
        {
            IQueryable<Speaker> query = _context.Speakers
                                                .AsNoTracking()
                                                .Include(s => s.SocialNetworks);

            if (includeEvents)
            {
                query = query.Include(s => s.EventSpeakers)
                             .ThenInclude(e => e.Event);
            }

            query = query.OrderBy(e => e.Id)
                         .Where(s => s.Id == id);

            return query.FirstOrDefault();
        }
        #endregion
    }
}