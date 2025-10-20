namespace MinimalApi.Endpoints
{
    public static class CategoryEndpoints
    {

        public static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/categories");
            // Define category-related endpoints here
            group.MapPost("/", CreateCategory);
            group.MapPut("/{id}", UpdateCategory);
            group.MapDelete("/{id}", DeleteCategory);
        }
        private static IResult CreateCategory(int id)
        {
            // Logic to create a category

            return Results.Ok("Category created");
        }
        private static IResult UpdateCategory(int id)
        {
            // Logic to update a category
            return Results.Ok($"Category {id} updated");
        }
        private static IResult DeleteCategory(int id)
        {
            // Logic to delete a category
            return Results.Ok($"Category {id} deleted");
        }

    }
}
