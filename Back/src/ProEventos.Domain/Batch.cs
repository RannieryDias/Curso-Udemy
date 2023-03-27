namespace ProEventos.Domain
{
    public class Batch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Preco { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Ammount { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}