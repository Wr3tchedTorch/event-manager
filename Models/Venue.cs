namespace EventManager.Models;

public partial class Venue
{
    public enum Status 
    {
        Available,
        Unavailable
    }

    public int          Id            { get; set; }
    public string       Name          { get; set; } = null!;
    public string       City          { get; set; } = null!;
    public string       State         { get; set; } = null!;
    public string       Country       { get; set; } = null!;
    public string       Neighborhood  { get; set; } = null!;
    public Status       CurrentStatus { get; set; }
    public int?         HouseNumber   { get; set; }

    public List<Event> Events { get; set; } = [];
}
