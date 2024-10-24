using App.Data;
using App.Domain;

namespace App.Routes;

internal static class GoalRoute
{
    public static void GoalRoutes(this WebApplication app)
    {
        var goalsRoute = app.MapGroup("goals");

        goalsRoute.MapPost("",
            async (GoalRequest request, DataContext context) =>
            {
                var goal = new Goal(request.Name, request.Description, request.DaysOfWeek);

                await context.AddAsync(goal);
                await context.SaveChangesAsync();
            }
        );

        goalsRoute.MapGet("", () => "todas as tasks");
        goalsRoute.MapDelete("{goalId}", (string goalId) => $"apagar uma task {goalId}");
    }
}