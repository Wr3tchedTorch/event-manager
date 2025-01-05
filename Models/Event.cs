using System;
using System.Collections.Generic;

namespace EventManager.Models;

public partial class Event
{
    public int      Id          { get; set; }
    public string   Title       { get; set; } = null!;
    public string?  Description { get; set; }
    public DateTime Date        { get; set; }
    public int      VenueId     { get; set; }
    public int      OrganizerId { get; set; }

    public virtual Organizer Organizer { get; set; } = null!;
    public virtual Venue     Venue     { get; set; } = null!;
    
    public virtual ICollection<Atendee> Atendees { get; set; } = [];
}
