using Microsoft.AspNetCore.Authentication.JwtBearer;
using RateMovie.Domain.Security.AccessTokenProvider;

namespace RateMovie.Api.Contexts
{
    public class AccessTokenProvider(IHttpContextAccessor _ContextAccessor) : IAccessTokenProvider
    {
        public string GetToken()
        {
            var headerAuthorizationToken = _ContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();

            return headerAuthorizationToken[JwtBearerDefaults.AuthenticationScheme.Length..].Trim();
        }
    }
}
