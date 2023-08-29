using ProEventos.Application.Contracts;
using ProEventos.Domain;
using ProEventos.Persistence.Contracts;

namespace ProEventos.Application
{
    public class EventService : IEventService
    {
        private readonly IGeneralPersistence generalPersistence;
        private readonly IEventPersistence eventPersistence;

        public EventService(IGeneralPersistence generalPersistence, IEventPersistence eventPersistence)
        {
            this.generalPersistence = generalPersistence;
            this.eventPersistence = eventPersistence;
        }

        public async Task<Event> AddEvents(Event myEvent)
        {
            try
            {
                generalPersistence.Add<Event>(myEvent);

                if (await generalPersistence.SaveChangesAsync())
                {
                    return await eventPersistence.GetEventByIdAsync(myEvent.Id, false);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> UpdateEvent(int eventId, Event myEvent)
        {
            try
            {
                var eventElement = await eventPersistence.GetEventByIdAsync(eventId, false);
                if (eventElement == null) { return null; }

                myEvent.Id = eventElement.Id;

                generalPersistence.Update(myEvent);

                if (await generalPersistence.SaveChangesAsync())
                {
                    return await eventPersistence.GetEventByIdAsync(myEvent.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvent(int eventId)
        {
            try
            {
                var eventElement = await eventPersistence.GetEventByIdAsync(eventId, false);
                if (eventElement == null) { throw new Exception("Evento não encontrado!"); }

                generalPersistence.Delete<Event>(eventElement);

                return await generalPersistence.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventsAsync(bool includeSpeakers = false)
        {
            try
            {
                var events = await eventPersistence.GetAllEventsAsync(includeSpeakers);
                if (events == null) { return null; }

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event[]> GetAllEventsByThemeAsync(string theme, bool includeSpeakers = false)
        {
            try
            {
                var events = await eventPersistence.GetAllEventsByThemeAsync(theme, includeSpeakers);
                if (events == null) { return null; }

                return events;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Event> GetEventByIdAsync(int eventId, bool includeSpeakers = false)
        {
            try
            {
                var eventEntity = await eventPersistence.GetEventByIdAsync(eventId, includeSpeakers);
                if (eventEntity == null) { return null; }

                return eventEntity;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}