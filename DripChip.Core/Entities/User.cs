using DripChip.Core.Entities.Abstract;

namespace DripChip.Core.Entities;

public class User : BaseEntity<int>
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}