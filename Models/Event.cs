namespace EventManager.Models;

public class Event
{
    public int      Id          { get; set; }
    public string   Title       { get; set; } = null!;
    public DateTime Date        { get; set; }
    public string?  Description { get; set; }
    public int      VenueId     { get; set; }
    public int      OrganizerId { get; set; }

    public virtual Organizer   Organizer     { get; set; } = null!;
    public virtual Venue       Venue         { get; set; } = null!;
    
    public List<Atendee>? Atendees { get; } = [];
}
