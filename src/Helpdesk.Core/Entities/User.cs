using Helpdesk.Core.ValueObjects;

namespace Helpdesk.Core.Entities;

public class User
{
    public Guid Id { get;  set; }
    public string Email { get; private set; }
    public string Company { get; private set; }
    public Role Role { get; private set; }

    private User(Guid id, string email, string company, int role)
    {
        Id = id;
        Email = email;
        Company = company;
        Role = role;
    }
    
    public User() {}

    public static User Create(string email, string company, int role)
    {
        return new User(
            id: Guid.NewGuid(),
            email: email,
            company: company,
            role: role
            );
    }
    
    
}