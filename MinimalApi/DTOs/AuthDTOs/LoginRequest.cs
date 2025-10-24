namespace MinimalApi.DTOs.AuthDTOs

{
    // DTO for login request
    public record LoginRequest
        (

        string Email,

        string Password
        );
}
