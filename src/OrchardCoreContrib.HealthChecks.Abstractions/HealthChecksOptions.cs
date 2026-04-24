namespace OrchardCoreContrib.HealthChecks;

/// <summary>
/// Represents a programmable health chekcs options.
/// </summary>
public class HealthChecksOptions
{
    /// <summary>
    /// Gets or sets the health check URL. Default to "/health.
    /// </summary>
    public string Url { get; set; } = "/health";

    /// <summary>
    /// Gets or sets the HTTP endpoint path used to check application liveness. Default to "/health/live".
    /// </summary>
    public string LivenessPath { get; set; } = "/health/live";

    /// <summary>
    /// Gets or sets the HTTP endpoint path used to check application readiness. Default to "/health/ready".
    /// </summary>
    public string ReadinessPath { get; set; } = "/health/ready";

    /// <summary>
    /// Whether to show the details for the checks dependency or not. Default to <c>false</c>.
    /// </summary>
    public bool ShowDetails { get; set; }
}
