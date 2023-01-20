namespace ExeVUB.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool IsPrivate { get; set; }
    public string Link { get; set; }
    public string Github { get; set; }
    public string Technologies { get; set; }
    public string Image { get; set; }
}