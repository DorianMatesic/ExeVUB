using System.ComponentModel.DataAnnotations.Schema;
namespace ExeVUB.Models;

public class Project
{
    public int Id { get; set; }
    public string Name { get; set; }//person - name, age, year, 
    public string Description { get; set; }//mozda predmet jos
    public DateTime Date { get; set; }
    public bool IsPrivate { get; set; }
    public string Link { get; set; }
    public string Github { get; set; }
    public string Technologies { get; set; }
    public string Image { get; set; }
    [NotMapped]
    public IFormFile Img { get; set; }
}