using ProEventos.Domain;

namespace ProEventos.Persistence.Contracts
{
    public interface ISpeakerPersistence
    {
        #region Speakers
        Task<Speaker[]> GetAllSpeakersAsync(bool includeEvents);
        Task<Speaker> GetSpeakerByNameAsync(string name, bool includeEvents);
        Task<Speaker> GetSpeakerByIdAsync(int id, bool includeEvents);
        #endregion
    }
}