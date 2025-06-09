using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Test2A.Models;

public class DatabaseContext : DbContext
{
    public DbSet<Race> Races { get; set; }
    public DbSet<RaceParticipation> RaceParticipations { get; set; }
    public DbSet<Racer> Racers { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<TrackRace> TrackRaces { get; set; }
    protected DatabaseContext()
    {
    }
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }
 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Race>(a =>
        {
            a.ToTable("Race");
            a.HasKey(r => r.RaceId);
            a.Property(r => r.Name).HasMaxLength(50);
            a.Property(r => r.Location).HasMaxLength(100);
        });
 
        modelBuilder.Entity<Racer>(a =>
        {
            a.ToTable("Racer");
            a.HasKey(r => r.RacerId);
            a.Property(r => r.FirstName).HasMaxLength(50);
            a.Property(r => r.LastName).HasMaxLength(100);
        });
 
        modelBuilder.Entity<Track>(a =>
        {
            a.ToTable("Track");
            a.HasKey(t => t.TrackId);
            a.Property(t => t.Name).HasMaxLength(100);
            a.Property(t => t.LengthInKm).HasColumnType("decimal(5,2)");
        });
 
        modelBuilder.Entity<RaceParticipation>(a =>
        {
            a.ToTable("Race_Participation");
            a.HasKey(rp => new { rp.TrackRaceId, rp.RacerId });
            a.HasOne(rp => rp.TrackRace)
                .WithMany(tr => tr.RaceParticipations)
                .HasForeignKey(rp => rp.TrackRaceId)
                .OnDelete(DeleteBehavior.Cascade);
            a.HasOne(rp => rp.Racer)
                .WithMany(r => r.RaceParticipations)
                .HasForeignKey(rp => rp.RacerId)
                .OnDelete(DeleteBehavior.Cascade);
        });
 
        modelBuilder.Entity<TrackRace>(a =>
        {
            a.ToTable("Track_Race");
            a.HasKey(tr => tr.TrackRaceId);
            a.HasOne(tr => tr.Track)
                .WithMany(t => t.TrackRaces)
                .HasForeignKey(tr => tr.TrackId)
                .OnDelete(DeleteBehavior.Cascade);
            a.HasOne(r => r.Race)
                .WithMany(r => r.TrackRaces)
                .HasForeignKey(tr => tr.RaceId)
                .OnDelete(DeleteBehavior.Cascade);
            a.Property(tr => tr.BestLapTimeInSeconds).IsRequired(false);
        });
 
        modelBuilder.Entity<Race>().HasData(new List<Race>()
        {
            new Race() { RaceId = 1, Name = "RaceOne", Location = "Warsaw" }
        });
        modelBuilder.Entity<Racer>().HasData(new List<Racer>()
        {
            new Racer() { RacerId = 1, FirstName = "Robert", LastName = "Kubica" }
        });
        modelBuilder.Entity<Track>().HasData(new List<Track>()
        {
            new Track() { TrackId = 1, Name = "Aleje Jerozolimskie", LengthInKm = 4.21m }
        });
        modelBuilder.Entity<TrackRace>().HasData(new List<TrackRace>()
        {
            new TrackRace() { TrackRaceId = 1, TrackId = 1, RaceId = 1, Laps = 78, BestLapTimeInSeconds = 68 }
        });
        modelBuilder.Entity<RaceParticipation>().HasData(new List<RaceParticipation>()
        {
            new RaceParticipation() { TrackRaceId = 1, RacerId = 1 }
        });
    }
}