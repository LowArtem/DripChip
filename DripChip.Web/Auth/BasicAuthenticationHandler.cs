using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using DripChip.Application.Dto;
using DripChip.Application.Services.Common;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace DripChip.Web.Auth;

public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
{
    private readonly IUserService _userService;

    public BasicAuthenticationHandler(
        IOptionsMonitor<AuthenticationSchemeOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IUserService userService)
        : base(options, logger, encoder, clock)
    {
        _userService = userService;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        // Skip authentication if endpoint has [AllowAnonymous] attribute
        var endpoint = Context.GetEndpoint();
        var allowAnonymous = endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null;

        if (!Request.Headers.ContainsKey("Authorization") && !allowAnonymous)
            return AuthenticateResult.Fail("Missing Authorization Header");
        if (!Request.Headers.ContainsKey("Authorization") && allowAnonymous)
            return AuthenticateResult.NoResult();


        var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
        var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
        var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
        var email = credentials[0];
        var password = credentials[1];
        
        var result = await _userService.Authenticate(new UserRequestDto.Authenticate(email, password));
   
        switch (result.IsSuccess)
        {
            case false when !allowAnonymous:
                return AuthenticateResult.Fail(result.Exception.Message);
            case false when allowAnonymous:
                return AuthenticateResult.NoResult();
        }

        switch (result.Value)
        {
            case null when !allowAnonymous:
                return AuthenticateResult.Fail("Invalid email or password");
            case null when allowAnonymous:
                return AuthenticateResult.NoResult();
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, result.Value.Id.ToString()),
            new Claim(ClaimTypes.Email, result.Value.Email),
        };
        var identity = new ClaimsIdentity(claims, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);
        var ticket = new AuthenticationTicket(principal, Scheme.Name);

        return AuthenticateResult.Success(ticket);
    }
}