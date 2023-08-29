using ProEventos.Domain;

namespace ProEventos.Persistence.Contracts
{
    public interface IEventPersistence
    {
        #region Events
        Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);
        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false);
        #endregion
    }
}