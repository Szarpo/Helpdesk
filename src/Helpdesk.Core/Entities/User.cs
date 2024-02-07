using Helpdesk.Core.ValueObjects;

namespace Helpdesk.Core.Entities;

public class User
{
    public Guid Id { get;  set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public Company Company { get; private set; }
    public Role Role { get; private set; }
    public IsActive IsActive { get; private set; }
    

    private User(Guid id, string email, Password password, string company, int role, bool isActive)
    {
        Id = id;
        Email = email;
        Password = password;
        Company = company;
        Role = role;
        IsActive = isActive;
    }
    
    public User() {}

    public static User Create(string email, Password password, string company, int role, bool isActive)
    {
        return new User(
            id: Guid.NewGuid(),
            email: email,
            password: password,
            company: company,
            role: role,
            isActive: isActive
            );
    }
    
    
}