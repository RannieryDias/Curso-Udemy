namespace ProEventos.Domain
{
    public class Event
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime? EventDate { get; set; }
        public string Theme { get; set; }
        public int Capacity { get; set; }
        public string ImageUrl { get; set; }
        public string Phone{ get; set; }
        public IEnumerable<Batch> Batches { get; set; }
        public IEnumerable<SocialNetwork> SocialNetworks { get; set; }
        public IEnumerable<EventSpeaker> EventSpeakers { get; set; }
    }
}