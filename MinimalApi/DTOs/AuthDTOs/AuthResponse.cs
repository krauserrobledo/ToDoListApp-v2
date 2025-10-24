namespace MinimalApi.DTOs.AuthDTOs

{
    // DTO for authentication response
    public record AuthResponse
        (

        string Token,
        
        string Email
        );

}
