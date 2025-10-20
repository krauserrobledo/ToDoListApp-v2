namespace MinimalApi.Endpoints
{
    public static class TaskEndpoints
    {
        public static void MapTaskEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/tasks");
            // Define task-related endpoints here
            group.MapPost("/", CreateTask);
            group.MapPut("/{id}", UpdateTask);
            group.MapDelete("/{id}", DeleteTask);
        }
        private static IResult CreateTask()
        {
            // Logic to create a task
            return Results.Ok("Task created");
        }
        private static IResult UpdateTask(int id)
        {
            // Logic to update a task
            return Results.Ok($"Task {id} updated");
        }
        private static IResult DeleteTask(int id)
        {
            // Logic to delete a task
            return Results.Ok($"Task {id} deleted");
        }
    }
}
