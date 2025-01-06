using Microsoft.EntityFrameworkCore;

namespace EventManager.Models;

public class EventManagerContext : DbContext
{
    public DbSet<Atendee>      Atendees      { get; set; }
    public DbSet<Event>        Events        { get; set; }
    public DbSet<Organizer>    Organizers    { get; set; }
    public DbSet<Venue>        Venues        { get; set; }

    public EventManagerContext(DbContextOptions<EventManagerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Event>().HasMany(e => e.Atendees)
                                    .WithMany(a => a.Events)
                                    .UsingEntity<Dictionary<string, object>>("EventHasAtendee", 
                                    join => join.HasData(
                                        new {EventsId = 1, AtendeesId = 1},
                                        new {EventsId = 1, AtendeesId = 2}
                                    ));

        modelBuilder.Entity<Atendee>().HasData(
            new Atendee 
            {
                Id = 1,
                Name   = "Rafael Portugal",
                CurrentStatus = Atendee.Status.Active,
                Description = "Comediante e ator do porta dos fundos",
                ProfilePicPath = ""
            },
            new Atendee 
            {
                Id = 2,
                Name   = "Palhaço Tubinho",
                CurrentStatus = Atendee.Status.Active,
                Description = "Palhaço profissional",
                ProfilePicPath = ""
            }
        );

        modelBuilder.Entity<Venue>().HasData(
            new Venue
            {
                Id = 1,
                Name = "Estação",
                City = "Guaratinguetá",
                State = "São paulo",
                Country = "Brasil",
                Neighborhood = "Praça Condessa de Frontin",
                CurrentStatus = Venue.Status.Available,
                HouseNumber = 82
            }
        );

        modelBuilder.Entity<Organizer>().HasData(
            new Organizer
            {
                Id = 1,
                Name = "Eric Moura",
                Email = "ericmoura@gmail.com",
                Password = "coxinha123"
            }
        );

        modelBuilder.Entity<Event>().HasData(
            new Event
            {
                Id = 1,
                Title = "Palestra sobre comédia",
                Date = new DateTime(2025, 3, 30, 10, 0, 0),
                Description = "Uma palestra apresentada por um comediante do porta dos fundos, explorando a ideia por trás das risadas.",
                VenueId = 1,
                OrganizerId = 1
            }
        );
        
        base.OnModelCreating(modelBuilder);
    }
}
