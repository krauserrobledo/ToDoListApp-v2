namespace MinimalApi.DTOs
{
    // Task DTOs
    public record TaskCreateDTO(
        string Title,
        string Description,
        DateTime? DueDate,
        string Status
        );

    public record TaskUpdateDTO(
        string Id,
        string Title,
        string Description,
        DateTime? DueDate,
        string Status,
        List<string> TagIds,
        List<string> CategoryIds);
}
