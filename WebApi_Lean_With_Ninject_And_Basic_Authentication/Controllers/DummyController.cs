using System;
using System.Security.Claims;
using System.Web.Http;
using WebApi_Lean_With_Ninject_And_Basic_Authentication.Filters;
using WebApi_Lean_With_Ninject_And_Basic_Authentication.Services;

namespace WebApi_Lean_With_Ninject_And_Basic_Authentication.Controllers
{
    [IdentityBasicAuthentication]
    [Authorize]
    public class DummyController : ApiController
    {
        private readonly IProvideSomeDependency _dependency;

        public DummyController(IProvideSomeDependency dependency)
        {
            if (dependency == null) throw new ArgumentNullException(nameof(dependency));
            _dependency = dependency;
        }

        [HttpGet]
        public string Hello()
        {
            var identity = User.Identity as ClaimsIdentity;
            var username = "(anonymous)";
            if (identity != null && identity.IsAuthenticated)
            {
                username = identity.Name;
            }

            return $"Hello World {username} {_dependency.GetSomeDependentValue()}";
        }
    }
}
