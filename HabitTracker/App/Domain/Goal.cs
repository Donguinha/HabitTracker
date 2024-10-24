using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain;

public class Goal
{
    public Goal(string name, string description, IEnumerable<int>? daysOfWeek)
    {
        Name = name;
        Description = description;
        DaysOfWeek = daysOfWeek ?? new List<int> { 1, 2, 3, 4, 5, 6, 7 };
    }

    public Guid Id { get; init; } = Guid.NewGuid();
    public bool Completed { get; private set; }
    public IEnumerable<int> DaysOfWeek { get; private set; }
    [MaxLength(100)] public string Name { get; private set; }
    [MaxLength(255)] public string Description { get; private set; }
}