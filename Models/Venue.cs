using System;
using System.Collections.Generic;

namespace EventManager.Models;

public partial class Venue
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Adress { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
