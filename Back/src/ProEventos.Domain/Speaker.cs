namespace ProEventos.Domain
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MiniProfile { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<SocialNetwork>? SocialNetworks { get; set; }
        public IEnumerable<EventSpeaker>? EventSpeakers { get; set; }
    }
}