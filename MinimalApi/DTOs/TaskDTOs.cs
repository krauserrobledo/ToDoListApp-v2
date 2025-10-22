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
        int Id,
        string Title,
        string Description,
        DateTime? DueDate,
        string Status,
        List<int> TagIds,
        List<int> CategoryIds);
}
