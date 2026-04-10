using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using OrchardCore.Security;
using OrchardCore.Security.Permissions;

namespace OrchardCoreContrib.Testing.Security;

public sealed class PermissionContextAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly PermissionsContext _permissionsContext;

    public PermissionContextAuthorizationHandler(IHttpContextAccessor httpContextAccessor, IDictionary<string, PermissionsContext> permissionsContexts)
    {
        _permissionsContext = new PermissionsContext();

        if (httpContextAccessor.HttpContext is null)
        {
            return;
        }

        var request = httpContextAccessor.HttpContext.Request;

        if (request?.Headers.ContainsKey(nameof(PermissionsContext)) == true &&
            permissionsContexts.TryGetValue(request.Headers[nameof(PermissionsContext)], out var permissionsContext))
        {
            _permissionsContext = permissionsContext;
        }
    }

    public PermissionContextAuthorizationHandler(PermissionsContext permissionsContext)
    {
        _permissionsContext = permissionsContext;
    }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        var permissions = (_permissionsContext.AuthorizedPermissions ?? []).ToList();

        if (!_permissionsContext.UsePermissionsContext)
        {
            context.Succeed(requirement);
        }
        else if (permissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }
        else
        {
            var grantingNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            GetGrantingNamesInternal(requirement.Permission, grantingNames);

            if (permissions.Any(p => grantingNames.Contains(p.Name)))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }

        return Task.CompletedTask;
    }

    private static void GetGrantingNamesInternal(Permission permission, HashSet<string> stack)
    {
        stack.Add(permission.Name);

        if (permission.ImpliedBy != null && permission.ImpliedBy.Any())
        {
            foreach (var impliedBy in permission.ImpliedBy)
            {
                if (impliedBy == null || stack.Contains(impliedBy.Name))
                {
                    continue;
                }

                GetGrantingNamesInternal(impliedBy, stack);
            }
        }
    }
}
