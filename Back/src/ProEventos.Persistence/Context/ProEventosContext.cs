using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;

namespace ProEventos.Persistence.Context
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EventSpeaker>()
                        .HasKey(x => new {x.EventId, x.SpeakerId});

            modelBuilder.Entity<Event>()
                .HasMany(x => x.SocialNetworks)
                .WithOne(x => x.Event)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Speaker>()
                .HasMany(x => x.SocialNetworks)
                .WithOne(x => x.Speaker)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}