namespace App.Domain;

public record GoalRequest(string Name, string Description, IEnumerable<int>? DaysOfWeek);