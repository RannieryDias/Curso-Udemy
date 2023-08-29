using ProEventos.Domain;

namespace ProEventos.Application.Contracts
{
    public interface IEventService
    {
        Task<Event> AddEvents(Event myEvent);
        Task<Event> UpdateEvent(int EventId, Event myEvent);
        Task<bool> DeleteEvent(int eventId);

        Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false);
        Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false);
        Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false);
    }
}