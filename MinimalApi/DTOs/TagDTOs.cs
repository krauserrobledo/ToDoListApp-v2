namespace MinimalApi.DTOs
{
    // Tag DTOs
    public record TagCreateDTO(string Name, string User);
    public record TagUpdateDTO(int Id, string Name);
}
