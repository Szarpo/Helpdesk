using System.Security.Authentication;
using System.Security.Claims;
using Helpdesk.Application.Auth;
using Helpdesk.Core.Entities;
using Helpdesk.Core.Exceptions;
using Helpdesk.Core.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Helpdesk.Infrastructure.Auth;

public class CookieAuthorizationService : ICookieAuthorizationService
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher<User> _passwordHasher;
    private readonly IHttpContextAccessor _httpContextAccessor;
 
    public CookieAuthorizationService(IUserRepository userRepository, IPasswordHasher<User> passwordHasher, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _httpContextAccessor = httpContextAccessor;
    }
    
    public async Task SignIn(string email, string password)
    {
        var user = await _userRepository.GetUserByEmail(email);

        if (user is null)
        {
            throw new InvalidCredentialException();
        }

        if (user.IsActive == false) 
        {
            throw new UserIsNotActiveException(user.Email);
        }

        var passwordVerificationResult =  _passwordHasher.VerifyHashedPassword(user, user.Password, password);

        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            throw new InvalidCredentialException();
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Id.ToString()),
            new Claim(ClaimTypes.Role, user.Role),
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

        await _httpContextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity));

    }

    public Task SignOut()
    {
        throw new NotImplementedException();
    }
}