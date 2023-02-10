namespace DripChip.Core.RequestDto;

public static class UserRequestDto
{
    public record Authenticate(string Email, string Password);
    
    public record Registration(string FirstName, string LastName, string Email, string Password);
}