using OrchardCoreContrib.Testing;

namespace OrchardCoreContrib.Navigation.Tests;

public class BlogSiteContext : SiteContextBase<OrchardCoreStartup>
{
    public BlogSiteContext() => Options.RecipeName = "Blog";
}
