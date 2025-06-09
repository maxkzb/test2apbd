namespace Test2A.DTOs;

public class RacerParticipationDto
{
    public int RacerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<RaceParticipationDetailsDto> Participations { get; set; }
}

public class RaceParticipationDetailsDto
{
    public RaceInfoDto Race { get; set; }
    public TrackInfoDto Track { get; set; }
    public int Laps { get; set; }
    public int FinishTimeInSeconds { get; set; }
    public int Position { get; set; }
}

public class RaceInfoDto
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }
}

public class TrackInfoDto
{
    public string Name { get; set; }
    public decimal LengthInKm { get; set; }
}

public class AddParticipationRequest
{
    public string RaceName { get; set; }
    public string TrackName { get; set; }
    public List<AddParticipantDto> Participations { get; set; }
}
public class AddParticipantDto
{
    public int RacerId { get; set; }
    public int Position { get; set; }
    public int FinishTimeInSeconds { get; set; }
}
