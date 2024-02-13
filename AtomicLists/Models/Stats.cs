using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Text.Json;

namespace AtomicLists.Models;

public class Stats
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    
    public int TotalTasks { get; set; }
    public int TotalCompleted { get; set; }
    public int TotalIncomplete { get; set; }

    public float PercentComplete {
    get => PercentComplete;
    set
    {
        if (TotalTasks == 0)
            PercentComplete = 0;
        else
            PercentComplete = (float)Math.Round((TotalCompleted / (float)TotalTasks) * 100, 2);
    }
    }
    
    // Used to make pie charts
    [NotMapped]
    public Vector<string> AreaNames { get; set; }
    [NotMapped]
    public Vector<int> NumberOfTasksByArea { get; set; }
    [NotMapped]
    public Vector<float> PercentCompleteByArea { get; set; }
    
    public string AreaNamesSerialized
    {
        get => JsonSerializer.Serialize(AreaNames);
        set => AreaNames = JsonSerializer.Deserialize<Vector<string>>(value);
    }
    public string NumberOfTasksByAreaSerialized
    {
        get => JsonSerializer.Serialize(NumberOfTasksByArea);
        set => NumberOfTasksByArea = JsonSerializer.Deserialize<Vector<int>>(value);
    }
    public string PercentCompleteByAreaSerialized
    {
        get => JsonSerializer.Serialize(PercentCompleteByArea);
        set => PercentCompleteByArea = JsonSerializer.Deserialize<Vector<float>>(value);
    }
        
        
        
    
}
