using Microsoft.EntityFrameworkCore;
using Test2A.DTOs;

namespace Test2A.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<RacerParticipationDto> GetRacerParticipation(int racerId)
    {
        var racerParticipations = await _context.RaceParticipations
            .Where(p => p.RacerId == racerId)
            .Select(p => new RacerParticipationDto()
            {
                RacerId = p.RacerId,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Participations = p.ParticipationDetails.Select(pd => new ParticipationDetailsDto()
                {
                    Race = new RaceInfoDto()
                    {
                        Name = pd.Name,
                        Location = pd.Location,
                        Date = pd.Date
                    },
                    Track = new TrackInfoDto()
                    {
                        Name = pd.Name,
                        LengthInKm = pd.LengthInKm
                    },
                    Laps = pd.Laps,
                    FinishTimeInSeconds = pd.FinishTimeInSeconds,
                    Position = pd.Position
                }).ToList()
            }).FirstOrDefaultAsync();
        
        return racerParticipations;
    }
}