using LinqToDB;
using OrchardCore.AdminDashboard.Indexes;
using OrchardCore.Alias.Indexes;
using OrchardCore.ArchiveLater.Indexes;
using OrchardCore.AuditTrail.Indexes;
using OrchardCore.Autoroute.Core.Indexes;
using OrchardCore.ContentLocalization.Records;
using OrchardCore.ContentManagement.Records;
using OrchardCore.Deployment.Indexes;
using OrchardCore.Layers.Indexes;
using OrchardCore.Lists.Indexes;
using OrchardCore.Notifications.Indexes;
using OrchardCore.OpenId.YesSql.Indexes;
using OrchardCore.PublishLater.Indexes;
using OrchardCore.Taxonomies.Indexing;
using OrchardCore.Users.Indexes;
using OrchardCore.Workflows.Indexes;
using YesSql;

namespace OrchardCoreContrib.Linq;

/// <summary>
/// Represents a data context for Orchard Core index tables.
/// </summary>
public class OrchardCoreDataContext : DataContextBase, IDisposable
{
    private readonly IStore _store;

    /// <summary>
    /// Initializes a new instance of a <see cref="OrchardCoreDataContext"/> with store.
    /// </summary>
    /// <param name="store">The underlying store of the database.</param>
    public OrchardCoreDataContext(IStore store)
    {
        _store = store;

        Connection = OrchardCoreDataConnectionFactory.Create(_store);
    }

    /// <summary>
    /// Gets a list of document items.
    /// </summary>
    public ITable<Document> Document => GetTable<Document>();

    /// <summary>
    /// Gets a list of dashboards widgets metadata.
    /// </summary>
    public ITable<DashboardPartIndex> DashboardPartIndex => GetTable<DashboardPartIndex>();

    /// <summary>
    /// Gets a list of auditing events.
    /// </summary>
    public ITable<AuditTrailEventIndex> AuditTrailEventIndex => GetTable<AuditTrailEventIndex>();

    /// <summary>
    /// Gets a list of deployment plans.
    /// </summary>
    public ITable<DeploymentPlanIndex> DeploymentPlanIndex => GetTable<DeploymentPlanIndex>();

    /// <summary>
    /// Gets a list of layers metadata.
    /// </summary>
    public ITable<LayerMetadataIndex> LayerMetadataIndex => GetTable<LayerMetadataIndex>();

    /// <summary>
    /// Gets a list of contained content items.
    /// </summary>
    public ITable<ContainedPartIndex> ContainedPartIndex => GetTable<ContainedPartIndex>();

    /// <summary>
    /// Gets a list of schedules content items.
    /// </summary>
    public ITable<PublishLaterPartIndex> PublishLaterPartIndex => GetTable<PublishLaterPartIndex>();

    /// <summary>
    /// Gets a list of tags / categories of content items.
    /// </summary>
    public ITable<TaxonomyIndex> TaxonomyIndex => GetTable<TaxonomyIndex>();

    /// <summary>
    /// Gets a list of workflows.
    /// </summary>
    public ITable<WorkflowIndex> WorkflowIndex => GetTable<WorkflowIndex>();

    /// <summary>
    /// Gets a list of workflow activities.
    /// </summary>
    public ITable<WorkflowBlockingActivitiesIndex> WorkflowBlockingActivitiesIndex => GetTable<WorkflowBlockingActivitiesIndex>();

    /// <summary>
    /// Gets a list of workflow types.
    /// </summary>
    public ITable<WorkflowTypeIndex> WorkflowTypeIndex => GetTable<WorkflowTypeIndex>();

    /// <summary>
    /// Gets a list of workflow types start activities.
    /// </summary>
    public ITable<WorkflowTypeStartActivitiesIndex> WorkflowTypeStartActivitiesIndex => GetTable<WorkflowTypeStartActivitiesIndex>();

    /// <summary>
    /// Gets a list of content items route.
    /// </summary>
    public ITable<AutoroutePartIndex> AutoroutePartIndex => GetTable<AutoroutePartIndex>();

    /// <summary>
    /// Gets a list of content item aliases.
    /// </summary>
    public ITable<AliasPartIndex> AliasPartIndex => GetTable<AliasPartIndex>();

    /// <summary>
    /// Gets a list of users.
    /// </summary>
    public ITable<UserIndex> UserIndex => GetTable<UserIndex>();

    /// <summary>
    /// Gets a list of user login provider.
    /// </summary>
    public ITable<UserByLoginInfoIndex> UserByLoginInfoIndex => GetTable<UserByLoginInfoIndex>();

    /// <summary>
    /// Gets a list of user claims.
    /// </summary>
    public ITable<UserByClaimIndex> UserByClaimIndex => GetTable<UserByClaimIndex>();

    /// <summary>
    /// Gets a list of OpenID tokens.
    /// </summary>
    public ITable<OpenIdTokenIndex> OpenIdTokenIndex => GetTable<OpenIdTokenIndex>();

    /// <summary>
    /// Gets a list of OpenID scopes.
    /// </summary>
    public ITable<OpenIdScopeIndex> OpenIdScopeIndex => GetTable<OpenIdScopeIndex>();

    /// <summary>
    /// Gets a list of OpenID authorizations.
    /// </summary>
    public ITable<OpenIdAuthorizationIndex> OpenIdAuthorizationIndex => GetTable<OpenIdAuthorizationIndex>();

    /// <summary>
    /// Gets a list of OpenID applications.
    /// </summary>
    public ITable<OpenIdApplicationIndex> OpenIdApplicationIndex => GetTable<OpenIdApplicationIndex>();

    /// <summary>
    /// Gets a list of content items.
    /// </summary>
    public ITable<ContentItemIndex> ContentItemIndex => GetTable<ContentItemIndex>();

    /// <summary>
    /// Gets a list of localized content items.
    /// </summary>
    public ITable<LocalizedContentItemIndex> LocalizedContentItemIndex => GetTable<LocalizedContentItemIndex>();

    /// <summary>
    /// Gets a list of notification content items.
    /// </summary>
    public ITable<NotificationIndex> NotificationIndex => GetTable<NotificationIndex>();

    /// <summary>
    /// Gets a list of achived content items.
    /// </summary>
    public ITable<ArchiveLaterPartIndex> ArchiveLaterPartIndex => GetTable<ArchiveLaterPartIndex>();

    /// <summary>
    /// Gets a list of users count by role name.
    /// </summary>
    public ITable<UserByRoleNameIndex> UserByRoleNameIndex => GetTable<UserByRoleNameIndex>();

    /// <summary>
    /// Gets a list of OpenID scopes count by resource.
    /// </summary>
    public ITable<OpenIdScopeByResourceIndex> OpenIdScopeByResourceIndex => GetTable<OpenIdScopeByResourceIndex>();

    /// <summary>
    /// Gets a list of OpenID apps count by redirect Uris.
    /// </summary>
    public ITable<OpenIdAppByRedirectUriIndex> OpenIdAppByRedirectUriIndex => GetTable<OpenIdAppByRedirectUriIndex>();

    /// <summary>
    /// Gets a list of OpenID apps count by logout Uris.
    /// </summary>
    public ITable<OpenIdAppByLogoutUriIndex> OpenIdAppByLogoutUriIndex => GetTable<OpenIdAppByLogoutUriIndex>();

    /// <inheritdoc/>
    public void Dispose() => _store.Dispose();
}
