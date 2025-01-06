using System;
using System.Collections.Generic;

namespace EventManager.Models;

public class Organizer
{
    public int    Id       { get; set; }
    public string Name     { get; set; } = null!;
    public string Email    { get; set; } = null!;
    public string Password { get; set; } = null!;

    public List<Event> Events { get; } = [];
}
