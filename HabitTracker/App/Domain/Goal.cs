using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain;

public class Goal
{
    private Goal()
    {
    }

    public Goal(bool completed, string name, string description, IEnumerable<int>? daysOfWeek)
    {
        Completed = completed;
        Name = name;
        Description = description;
        OccursOn = daysOfWeek == null
            ? Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().ToList()
            : daysOfWeek.Select(d => (DayOfWeek)d).ToList();
    }

    public Guid Id { get; init; } = Guid.NewGuid();
    public bool Completed { get; private set; }

    [NotMapped] private IEnumerable<DayOfWeek> OccursOn { get; set; }

    // Propriedade de suporte para armazenar os dias da semana como inteiros
    [Column("OccursOn")]
    public string OccursOnString
    {
        get => string.Join(',', OccursOn.Select(d => ((int)d).ToString()));
        private set => OccursOn = value.Split(',').Select(int.Parse).Cast<DayOfWeek>().ToList();
    }

    [MaxLength(100)] public string Name { get; private set; }
    [MaxLength(255)] public string Description { get; private set; }
}