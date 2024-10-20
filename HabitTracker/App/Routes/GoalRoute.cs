namespace App.Routes;

internal static class GoalRoute
{
    public static void GoalRoutes(this WebApplication app)
    {
        app.MapGet("goals", () => "todas as tasks");
        app.MapDelete("goals/{goalId}", (string goalId) => $"apagar uma task {goalId}");
    }
}