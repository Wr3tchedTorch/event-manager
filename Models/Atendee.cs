﻿using System;
using System.Collections.Generic;

namespace EventManager.Models;

public partial class Atendee
{
    public int    Id   { get; set; }
    public string Name { get; set; } = null!;

    public virtual ICollection<Event> Events { get; set; } = [];
}
