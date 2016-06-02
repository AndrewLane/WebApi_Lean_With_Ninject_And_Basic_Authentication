using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace WebApi_Lean_With_Ninject_And_Basic_Authentication.Filters
{
    /// <summary>
    /// Taken from http://aspnet.codeplex.com/sourcecontrol/latest#Samples/WebApi/BasicAuthentication/ReadMe.txt
    /// </summary>
    public class IdentityBasicAuthenticationAttribute : BasicAuthenticationAttribute
    {
        protected override async Task<IPrincipal> AuthenticateAsync(string userName, string password, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (userName != "foo" || password != "bar")
            {
                //bad username/password combination
                return null;
            }

            cancellationToken.ThrowIfCancellationRequested();

            var claimsForThisUser = new List<Claim>
            {
                new Claim(ClaimTypes.Role, "Administrator"),
                new Claim(ClaimTypes.Name, "foobar")
            };

            return new ClaimsPrincipal(new ClaimsIdentity(claimsForThisUser, authenticationType: "dummyAuthentication"));
        }
    }
}