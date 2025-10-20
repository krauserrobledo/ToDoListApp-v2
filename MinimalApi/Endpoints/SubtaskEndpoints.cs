using Domain.Abstractions;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.DTOs;

namespace MinimalApi.Endpoints
{
    public static class SubtaskEndpoints
    {
        public static void MapSubtaskEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/subtasks");
            // Define subtask-related endpoints here
            group.MapPost("/", CreateSubtask).RequireAuthorization();
            group.MapPut("/{id}", UpdateSubtask).RequireAuthorization();
            group.MapDelete("/{id}", DeleteSubtask).RequireAuthorization();
        }
        private static async Task <IResult> CreateSubtask(
            [FromBody] SubtaskCreateDTO request,
            ISubtaskRepository subtaskRepository,
            HttpContext context)
        {
            // Logic to create a subtask
            try
            {
                // Validate request
                if (string.IsNullOrWhiteSpace(request.Title))
                    return Results.BadRequest("Title is required.");

                if (string.IsNullOrWhiteSpace(request.TaskId))
                    return Results.BadRequest("TaskId is required.");

                // Create new Subtask entity
                var newSubtask = new Subtask
                    {
                    Id = Guid.NewGuid().ToString(),
                    Title = request.Title,
                    TaskId = request.TaskId
                };

                // Save to repository
                var createdSubtask = await subtaskRepository.CreateSubtask(newSubtask);

                // Return success response
                return Results.Created($"/api/subtasks/{createdSubtask.Id}", new
                {
                    id = createdSubtask.Id,
                    title = createdSubtask.Title,
                    taskId = createdSubtask.TaskId
                });

            }
            catch (Exception ex)
            {
                // Log exception 
                return Results.Problem("An error occurred while creating the subtask: " + ex.Message );
            }
        }
        private static async Task<IResult> UpdateSubtask(
           string id,
           [FromBody] SubtaskUpdateDTO request,
           ISubtaskRepository subtaskRepository,
           HttpContext context)
        {
            try
            {
                // Check if the subtask exists
                var existingSubtask = await subtaskRepository.GetSubtaskById(id);
                if (existingSubtask == null)
                    return Results.NotFound($"Subtask with ID {id} not found");

                // Update properties
                if (!string.IsNullOrWhiteSpace(request.Title))
                    existingSubtask.Title = request.Title;


                // Repository call
                var updatedSubtask = await subtaskRepository.UpdateSubtask(existingSubtask);
                if (updatedSubtask == null)
                    return Results.NotFound($"Subtask with ID {id} not found");

                // Return response
                return Results.Ok(new
                {
                    id = updatedSubtask.Id,
                    title = updatedSubtask.Title,
                    taskId = updatedSubtask.TaskId
                });
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error updating subtask: {ex.Message}");
            }
        }

        private static async Task<IResult> DeleteSubtask(
            string id,
            ISubtaskRepository subtaskRepository,
            HttpContext context)
        {
            try
            {
                // 1. Verificar que la subtarea existe
                var existingSubtask = await subtaskRepository.GetSubtaskById(id);
                if (existingSubtask == null)
                    return Results.NotFound($"Subtask with ID {id} not found");

                // 2. Llamar al repository
                var deleted = await subtaskRepository.DeleteSubtask(id);

                if (!deleted)
                    return Results.NotFound($"Subtask with ID {id} not found");

                // 3. Retornar respuesta
                return Results.NoContent();
            }
            catch (Exception ex)
            {
                return Results.Problem($"Error deleting subtask: {ex.Message}");
            }
        }
    }
}