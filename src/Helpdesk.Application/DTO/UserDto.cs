namespace Helpdesk.Application.DTO;

public record UserDto
(
     Guid Id,
     string Email,
     string Company,
     string Role
);