using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace sample_core_webapi.Filters
{
    public class JwtAuthenticationAttribute : Attribute, IAsyncAuthorizationFilter, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            throw new NotImplementedException();
        }

        public Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            //var authorization = context.HttpContext.Request.Headers["Authorization"];

            //if (authorization == null || authorization.Scheme != "Bearer")
            //    return;

            //if (string.IsNullOrEmpty(authorization.Parameter))
            //{
            //    context.ErrorResult = new AuthenticationFailureResult("Missing Jwt Token", request);
            //    return;
            //}

            //var token = authorization.Parameter;
            //var principal = await AuthenticateJwtToken(token);

            //if (principal == null)
            //    context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);

            //else
            //    context.Principal = principal;

            throw new NotImplementedException();
        }
    }
}
