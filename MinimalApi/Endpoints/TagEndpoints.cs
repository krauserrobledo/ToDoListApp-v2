using Domain.Abstractions;

namespace MinimalApi.Endpoints
{
    public static class TagEndpoints
    {
        public static void MapTagEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/tags");
            // Define tag-related endpoints here
            group.MapPost("/", CreateTag);
            group.MapPut("/{id}", UpdateTag);
            group.MapDelete("/{id}", DeleteTag);
        }

        private static IResult CreateTag(ITagRepository tagRepository)
        {
            // Logic to create a tag
            return Results.Ok("Tag created");
        }

        private static IResult UpdateTag(int id)
        {
            // Logic to update a tag
            return Results.Ok($"Tag {id} updated");
        }

        private static IResult DeleteTag(int id)
        {
            // Logic to delete a tag
            return Results.Ok($"Tag {id} deleted");
        }
    }
}
