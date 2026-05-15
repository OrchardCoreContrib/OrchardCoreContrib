namespace OrchardCoreContrib.Templating;

/// <summary>
/// Represents an exception that is thrown when a template engine with the specified name is not found.
/// </summary>
/// <param name="name">The engine name.</param>
public class TemplateNotFoundException(string name) : Exception($"Template engine '{name}' was not found.");
