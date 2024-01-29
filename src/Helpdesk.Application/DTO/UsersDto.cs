namespace Helpdesk.Application.DTO;

public record UsersDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Company { get; set; }
    public string Role { get; set; }    
}