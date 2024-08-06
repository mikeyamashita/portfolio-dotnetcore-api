using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models;
public class ProjectDTO
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public string[]? Tags { get; set; }
    public string? Url { get; set; }
    public float? Type { get; set; }
}