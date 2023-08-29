using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Context;

namespace ProEventos.Persistence.Contracts
{
    public class EventPersistence : IEventPersistence
    {
        private readonly ProEventosContext _context;
        public EventPersistence(ProEventosContext context)
        {
            _context = context;
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        #region Events
        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                                              .AsNoTracking()
                                              .Include(e => e.Batches)
                                              .Include(s => s.SocialNetworks);

            if (includeSpeakers)
            {
                query = query.Include(e => e.EventSpeakers)
                             .ThenInclude(s => s.Speaker);
            }

            query = query.OrderBy(e => e.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                                             .AsNoTracking()
                                             .Include(e => e.Batches)
                                             .Include(s => s.SocialNetworks);

            if (includeSpeakers)
            {
                query = query.Include(e => e.EventSpeakers)
                             .ThenInclude(s => s.Speaker);
            }

            query = query.OrderBy(e => e.Id)
                         .Where(e => e.Theme.ToLower()
                                            .Contains(theme.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
        {
            IQueryable<Event> query = _context.Events
                                              .AsNoTracking()
                                              .Include(e => e.Batches)
                                              .Include(s => s.SocialNetworks);

            if (includeSpeakers)
            {
                query = query.Include(e => e.EventSpeakers)
                             .ThenInclude(s => s.Speaker);
            }

            query = query.OrderBy(e => e.Id)
                         .Where(e => e.Id == eventId);

            return await query.FirstOrDefaultAsync();
        }
        #endregion
    }
}