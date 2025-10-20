namespace MinimalApi.DTOs
{
    // Category DTOs
    public record CategoryCreateDTO(string Name, string Color, string User);

    public record CategoryUpdateDTO(int Id, string Name, string Color);

    public record CategoryDeleteDTO(int Id);


}
