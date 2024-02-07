namespace Helpdesk.Application.Auth;

public interface IAuthorizationService
{
    Task<AuthDto> SignIn(string email, string password);
    Task<AuthDto> RefreshToken(string expiredAccessToken, string refreshToken);
}