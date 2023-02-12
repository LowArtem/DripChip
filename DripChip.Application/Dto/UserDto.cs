namespace DripChip.Application.Dto;

public static class UserRequestDto
{
    public record Authenticate(string Email, string Password);
    
    public record AccountManagement(string FirstName, string LastName, string Email, string Password);

    public record Search(string? FirstName, string? LastName, string? Email, int From = 0, int Size = 10);
}

public static class UserResponseDto
{
    public record Info(int Id, string FirstName, string LastName, string Email);
}