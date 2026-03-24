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

    [Obsolete("This property is deprecated, use DashboardPartIndex instead.")]
    public ITable<DashboardPartIndex> Dashboards => GetTable<DashboardPartIndex>();

    /// <summary>
    /// Gets a list of dashboards widgets metadata.
    /// </summary>
    public ITable<DashboardPartIndex> DashboardPartIndex => GetTable<DashboardPartIndex>();

    [Obsolete("This property is deprecated, use AuditTrailEventIndex instead.")]
    public ITable<AuditTrailEventIndex> AuditEvents => GetTable<AuditTrailEventIndex>();

    /// <summary>
    /// Gets a list of auditing events.
    /// </summary>
    public ITable<AuditTrailEventIndex> AuditTrailEventIndex => GetTable<AuditTrailEventIndex>();

    [Obsolete("This property is deprecated, use DeploymentPlanIndex instead.")]
    public ITable<DeploymentPlanIndex> DeploymentPlans => GetTable<DeploymentPlanIndex>();

    /// <summary>
    /// Gets a list of deployment plans.
    /// </summary>
    public ITable<DeploymentPlanIndex> DeploymentPlanIndex => GetTable<DeploymentPlanIndex>();

    [Obsolete("This property is deprecated, use LayerMetadataIndex instead.")]
    public ITable<LayerMetadataIndex> Layers => GetTable<LayerMetadataIndex>();

    /// <summary>
    /// Gets a list of layers metadata.
    /// </summary>
    public ITable<LayerMetadataIndex> LayerMetadataIndex => GetTable<LayerMetadataIndex>();

    [Obsolete("This property is deprecated, use ContainedPartIndex instead.")]
    public ITable<ContainedPartIndex> Containers => GetTable<ContainedPartIndex>();

    /// <summary>
    /// Gets a list of contained content items.
    /// </summary>
    public ITable<ContainedPartIndex> ContainedPartIndex => GetTable<ContainedPartIndex>();

    [Obsolete("This property is deprecated, use PublishLaterPartIndex instead.")]
    public ITable<PublishLaterPartIndex> Publishes => GetTable<PublishLaterPartIndex>();

    /// <summary>
    /// Gets a list of schedules content items.
    /// </summary>
    public ITable<PublishLaterPartIndex> PublishLaterPartIndex => GetTable<PublishLaterPartIndex>();

    [Obsolete("This property is deprecated, use TaxonomyIndex instead.")]
    public ITable<TaxonomyIndex> Taxonomies => GetTable<TaxonomyIndex>();

    /// <summary>
    /// Gets a list of tags / categories of content items.
    /// </summary>
    public ITable<TaxonomyIndex> TaxonomyIndex => GetTable<TaxonomyIndex>();

    [Obsolete("This property is deprecated, use WorkflowIndex instead.")]
    public ITable<WorkflowIndex> Workflows => GetTable<WorkflowIndex>();

    /// <summary>
    /// Gets a list of workflows.
    /// </summary>
    public ITable<WorkflowIndex> WorkflowIndex => GetTable<WorkflowIndex>();

    [Obsolete("This property is deprecated, use WorkflowBlockingActivitiesIndex instead.")]
    public ITable<WorkflowBlockingActivitiesIndex> WorkflowBlockingActivities => GetTable<WorkflowBlockingActivitiesIndex>();

    /// <summary>
    /// Gets a list of workflow activities.
    /// </summary>
    public ITable<WorkflowBlockingActivitiesIndex> WorkflowBlockingActivitiesIndex => GetTable<WorkflowBlockingActivitiesIndex>();

    [Obsolete("This property is deprecated, use WorkflowTypeIndex instead.")]
    public ITable<WorkflowTypeIndex> WorkflowTypes => GetTable<WorkflowTypeIndex>();

    /// <summary>
    /// Gets a list of workflow types.
    /// </summary>
    public ITable<WorkflowTypeIndex> WorkflowTypeIndex => GetTable<WorkflowTypeIndex>();

    [Obsolete("This property is deprecated, use WorkflowTypeStartActivitiesIndex instead.")]
    public ITable<WorkflowTypeStartActivitiesIndex> WorkflowTypeStartActivities => GetTable<WorkflowTypeStartActivitiesIndex>();

    /// <summary>
    /// Gets a list of workflow types start activities.
    /// </summary>
    public ITable<WorkflowTypeStartActivitiesIndex> WorkflowTypeStartActivitiesIndex => GetTable<WorkflowTypeStartActivitiesIndex>();

    [Obsolete("This property is deprecated, use AutoroutePartIndex instead.")]
    public ITable<AutoroutePartIndex> Routes => GetTable<AutoroutePartIndex>();

    /// <summary>
    /// Gets a list of content items route.
    /// </summary>
    public ITable<AutoroutePartIndex> AutoroutePartIndex => GetTable<AutoroutePartIndex>();

    [Obsolete("This property is deprecated, use AliasPartIndex instead.")]
    public ITable<AliasPartIndex> Aliases => GetTable<AliasPartIndex>();

    /// <summary>
    /// Gets a list of content item aliases.
    /// </summary>
    public ITable<AliasPartIndex> AliasPartIndex => GetTable<AliasPartIndex>();

    [Obsolete("This property is deprecated, use UserIndex instead.")]
    public ITable<UserIndex> Users => GetTable<UserIndex>();

    /// <summary>
    /// Gets a list of users.
    /// </summary>
    public ITable<UserIndex> UserIndex => GetTable<UserIndex>();

    [Obsolete("This property is deprecated, use UserByLoginInfoIndex instead.")]
    public ITable<UserByLoginInfoIndex> LoginProviders => GetTable<UserByLoginInfoIndex>();

    /// <summary>
    /// Gets a list of user login provider.
    /// </summary>
    public ITable<UserByLoginInfoIndex> UserByLoginInfoIndex => GetTable<UserByLoginInfoIndex>();

    [Obsolete("This property is deprecated, use UserByClaimIndex instead.")]
    public ITable<UserByClaimIndex> UserClaims => GetTable<UserByClaimIndex>();

    /// <summary>
    /// Gets a list of user claims.
    /// </summary>
    public ITable<UserByClaimIndex> UserByClaimIndex => GetTable<UserByClaimIndex>();

    [Obsolete("This property is deprecated, use OpenIdTokenIndex instead.")]
    public ITable<OpenIdTokenIndex> OpenIdTokens => GetTable<OpenIdTokenIndex>();

    /// <summary>
    /// Gets a list of OpenID tokens.
    /// </summary>
    public ITable<OpenIdTokenIndex> OpenIdTokenIndex => GetTable<OpenIdTokenIndex>();

    [Obsolete("This property is deprecated, use OpenIdScopeIndex instead.")]
    public ITable<OpenIdScopeIndex> OpenIdScopes => GetTable<OpenIdScopeIndex>();

    /// <summary>
    /// Gets a list of OpenID scopes.
    /// </summary>
    public ITable<OpenIdScopeIndex> OpenIdScopeIndex => GetTable<OpenIdScopeIndex>();

    [Obsolete("This property is deprecated, use OpenIdAuthorizationIndex instead.")]
    public ITable<OpenIdAuthorizationIndex> OpenIdAuthorizations => GetTable<OpenIdAuthorizationIndex>();

    /// <summary>
    /// Gets a list of OpenID authorizations.
    /// </summary>
    public ITable<OpenIdAuthorizationIndex> OpenIdAuthorizationIndex => GetTable<OpenIdAuthorizationIndex>();

    [Obsolete("This property is deprecated, use OpenIdApplicationIndex instead.")]
    public ITable<OpenIdApplicationIndex> OpenIdApplications => GetTable<OpenIdApplicationIndex>();

    /// <summary>
    /// Gets a list of OpenID applications.
    /// </summary>
    public ITable<OpenIdApplicationIndex> OpenIdApplicationIndex => GetTable<OpenIdApplicationIndex>();

    [Obsolete("This property is deprecated, use ContentItemIndex instead.")]
    public ITable<ContentItemIndex> ContentItems => GetTable<ContentItemIndex>();

    /// <summary>
    /// Gets a list of content items.
    /// </summary>
    public ITable<ContentItemIndex> ContentItemIndex => GetTable<ContentItemIndex>();

    [Obsolete("This property is deprecated, use LocalizedContentItemIndex instead.")]
    public ITable<LocalizedContentItemIndex> LocalizedContentItems => GetTable<LocalizedContentItemIndex>();

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
