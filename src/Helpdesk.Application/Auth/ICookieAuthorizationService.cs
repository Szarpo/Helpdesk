namespace Helpdesk.Application.Auth;

public interface ICookieAuthorizationService
{
    Task SignIn(string email, string password);
    Task SignOut();
}