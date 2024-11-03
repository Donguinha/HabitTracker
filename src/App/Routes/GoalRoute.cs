using App.Data;
using App.Domain;
using Microsoft.EntityFrameworkCore;

namespace App.Routes;

internal static class GoalRoute
{
    public static void GoalRoutes(this WebApplication app)
    {
        var goalsRoute = app.MapGroup("goals");

        goalsRoute.MapPost("", async (GoalRequest request, DataContext context) =>
        {
            var goal = new Goal(request.Name, request.Description, request.DaysOfWeek);

            await context.AddAsync(goal);
            await context.SaveChangesAsync();

            return Results.Created();
        });

        goalsRoute.MapGet("", async (DataContext context) =>
        {
            var goals = await context.Goals.ToListAsync();

            return goals.Count == 0 ? Results.NotFound() : Results.Ok(goals);
        });

        goalsRoute.MapGet("{goalId}", async (Guid goalId, DataContext context) =>
        {
            var goal = await context.Goals.SingleOrDefaultAsync(x => x.Id == goalId);

            return goal == null ? Results.NotFound() : Results.Ok(goal);
        });

        goalsRoute.MapGet("{goalId}/done", async (Guid goalId, DataContext context) =>
        {
            var goal = await context.Goals.SingleOrDefaultAsync(x => x.Id == goalId);

            if (goal == null)
                return Results.NotFound();

            goal.Complete();

            await context.SaveChangesAsync();

            return Results.Ok();
        });

        goalsRoute.MapDelete("{goalId}", async (Guid goalId, DataContext context) =>
        {
            var goal = await context.Goals.SingleOrDefaultAsync(x => x.Id == goalId);

            if (goal == null)
                return Results.NotFound();

            context.Goals.Remove(goal);

            await context.SaveChangesAsync();

            return Results.Ok();
        });
    }
}