using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EventManager.Models;

public partial class EventManagerContext : DbContext
{
    public EventManagerContext()
    {
    }

    public EventManagerContext(DbContextOptions<EventManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Atendee> Atendees { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Organizer> Organizers { get; set; }

    public virtual DbSet<Venue> Venues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=EventManager;uid=root;pwd=Fiodor134978karamazov", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Atendee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("atendee");

            entity.Property(e => e.Name).HasMaxLength(45);

            entity.HasMany(d => d.Events).WithMany(p => p.Atendees)
                .UsingEntity<Dictionary<string, object>>(
                    "AtendeeHasEvent",
                    r => r.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Atendee_has_Event_Event1"),
                    l => l.HasOne<Atendee>().WithMany()
                        .HasForeignKey("AtendeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_Atendee_has_Event_Atendee1"),
                    j =>
                    {
                        j.HasKey("AtendeeId", "EventId")
                            .HasName("PRIMARY")
                            .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });
                        j.ToTable("atendee_has_event");
                        j.HasIndex(new[] { "AtendeeId" }, "fk_Atendee_has_Event_Atendee1_idx");
                        j.HasIndex(new[] { "EventId" }, "fk_Atendee_has_Event_Event1_idx");
                        j.IndexerProperty<int>("AtendeeId").HasColumnName("Atendee_Id");
                        j.IndexerProperty<int>("EventId").HasColumnName("Event_Id");
                    });
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("event");

            entity.HasIndex(e => e.OrganizerId, "fk_Event_User1_idx");

            entity.HasIndex(e => e.VenueId, "fk_Event_Venue_idx");

            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(150);
            entity.Property(e => e.OrganizerId).HasColumnName("Organizer_Id");
            entity.Property(e => e.Title).HasMaxLength(45);
            entity.Property(e => e.VenueId).HasColumnName("Venue_Id");

            entity.HasOne(d => d.Organizer).WithMany(p => p.Events)
                .HasForeignKey(d => d.OrganizerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Event_User1");

            entity.HasOne(d => d.Venue).WithMany(p => p.Events)
                .HasForeignKey(d => d.VenueId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Event_Venue");
        });

        modelBuilder.Entity<Organizer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("organizer");

            entity.Property(e => e.Name).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);
        });

        modelBuilder.Entity<Venue>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("venue");

            entity.Property(e => e.Adress).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
