using DripChip.Core.Entities.Abstract;

namespace DripChip.Core.Entities;

public class User : BaseEntity<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}