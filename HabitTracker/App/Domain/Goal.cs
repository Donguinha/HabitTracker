using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain;

public class Goal(string name, string description, IEnumerable<int>? daysOfWeek)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    
    [MaxLength(100)] 
    public string Name { get; private set; } = name;
    
    [MaxLength(255)] 
    public string Description { get; private set; } = description;
    
    public bool Completed { get; private set; }

    public IEnumerable<int> DaysOfWeek { get; private set; } = daysOfWeek ?? new List<int> { 1, 2, 3, 4, 5, 6, 7 };

    public DateTime CreatedAt { get; init; } = DateTime.Now;

    public void Complete() => Completed = true;
}