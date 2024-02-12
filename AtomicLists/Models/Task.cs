using System.ComponentModel.DataAnnotations;

namespace AtomicLists.Models;

public class Task
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? TaskDescription { get; set; }
    public string? Area { get; set; }
    public bool IsComplete { get; set; }
    public DateTime DateCreated { get; set; }
    public string? Priority { get; set; }
    
}