using OrchardCore.Security.Permissions;

namespace OrchardCoreContrib.Testing.Security;

public class PermissionsContext
{
    public PermissionsContext()
    {
        AuthorizedPermissions = [];
        UsePermissionsContext = false;
    }
    public IEnumerable<Permission> AuthorizedPermissions { get; set; }

    public bool UsePermissionsContext { get; set; }
}
