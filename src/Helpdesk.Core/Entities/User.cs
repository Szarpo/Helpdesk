namespace Helpdesk.Core.Entities;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Company { get; set; }
    public string Role { get; set; }

    private User(Guid id, string email, string company, string role)
    {
        Id = id;
        Email = email;
        Company = company;
        Role = role;
    }
    
    public User() {}
    
    
}