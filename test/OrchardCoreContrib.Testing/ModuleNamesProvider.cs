using OrchardCore.Modules;
using OrchardCore.Modules.Manifest;
using System.Reflection;

namespace OrchardCoreContrib.Testing;

public sealed class ModuleNamesProvider : IModuleNamesProvider
{
    private readonly IEnumerable<string> _moduleNames;

    public ModuleNamesProvider(Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(assembly);

        _moduleNames = Assembly.Load(new AssemblyName(assembly.GetName().Name))
            .GetCustomAttributes<ModuleNameAttribute>()
            .Select(m => m.Name);
    }

    public IEnumerable<string> GetModuleNames() => _moduleNames;
}
