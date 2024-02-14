namespace Helpdesk.Application.DTO;

public record UsersDto
(
     Guid Id,
     string Email,
     string Company,
     string Role,
     bool IsActive
);