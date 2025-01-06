namespace EventManager.Models;

public class Atendee
{
    public enum Status 
    {
        Active,
        Inactive
    }

    public int     Id             { get; set; }
    public string  Name           { get; set; } = null!;    
    public Status  CurrentStatus  { get; set; }
    public string? Description    { get; set; }
    public string  ProfilePicPath { get; set; } = null!;

    public List<Event>? Events { get; } = [];
}
