using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence
{
    public class ProEventosContext : DbContext
    {
        public ProEventosContext(DbContextOptions<ProEventosContext> options)
        : base (options) {}
        public DbSet<Event> Events {get; set;}
        public DbSet<Batch> Batches {get; set;}
        public DbSet<Speaker> Speakers {get; set;}
        public DbSet<EventSpeaker> EventSpeakers {get; set;}
        public DbSet<SocialNetwork> SocialNetworks {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventSpeaker>()
                        .HasKey(x => new {x.EventId, x.SpeakerId});
        }
    }
}