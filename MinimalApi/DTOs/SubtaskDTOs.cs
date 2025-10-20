namespace MinimalApi.DTOs
{
    // Subtask DTOs
    public record SubtaskCreateDTO(string Title, string TaskId);

    public record SubtaskUpdateDTO(string Id, string Title);

    public record SubtaskDeleteDTO(string Id);


}
