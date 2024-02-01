using Helpdesk.Core.ValueObjects;

namespace Helpdesk.Core.Entities;

public class User
{
    public Guid Id { get;  set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public string Company { get; private set; }
    public Role Role { get; private set; }
    

    private User(Guid id, string email, Password password, string company, int role)
    {
        Id = id;
        Email = email;
        Password = password;
        Company = company;
        Role = role;
    }
    
    public User() {}

    public static User Create(string email, Password password, string company, int role)
    {
        return new User(
            id: Guid.NewGuid(),
            email: email,
            password: password,
            company: company,
            role: role
            );
    }
    
    
}