namespace DripChip.Application.Dto;

public static class UserRequestDto
{
    public record Authenticate(string Email, string Password);
    
    public record Registration(string FirstName, string LastName, string Email, string Password);
}

public static class UserResponseDto
{
    public record Info(int Id, string FirstName, string LastName, string Email);
}