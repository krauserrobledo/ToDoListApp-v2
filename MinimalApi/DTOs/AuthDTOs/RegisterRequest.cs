namespace MinimalApi.DTOs.AuthDTOs

{
    // DTO for registration request
    public record RegisterRequest
        (

        string Email,

        string Password
        );

}
