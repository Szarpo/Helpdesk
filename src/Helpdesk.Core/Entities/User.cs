using Helpdesk.Core.ValueObjects;

namespace Helpdesk.Core.Entities;

public class User
{
    public Guid Id { get;  set; }
    public Email Email { get; private set; }
    public Password Password { get; private set; }
    public Company Company { get; private set; }
    public Role Role { get; private set; }
    public UserStatus Status { get; private set; }
    

    private User(Guid id, string email, Password password, string company, int role, int status)
    {
        Id = id;
        Email = email;
        Password = password;
        Company = company;
        Role = role;
        Status = status;
    }
    
    public User() {}

    public static User Create(string email, Password password, string company, int role, int status)
    {
        return new User(
            id: Guid.NewGuid(),
            email: email,
            password: password,
            company: company,
            role: role,
            status: status
            );
    }
    
    
}