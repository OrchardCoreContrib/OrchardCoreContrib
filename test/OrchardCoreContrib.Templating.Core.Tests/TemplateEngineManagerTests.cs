namespace OrchardCoreContrib.Templating.Tests;

public class TemplateEngineManagerTests
{
    [Fact]
    public void RegisterEngine_Null_Throws()
    {
        // Arrange
        var manager = new TemplateEngineManager();

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => manager.RegisterEngine(null!));
    }

    [Fact]
    public void RegisterEngine_ThenGetEngine_ReturnsRegisteredInstance()
    {
        // Arrange
        var engineName = "liquid";
        var manager = new TemplateEngineManager();
        var engine = new TestTemplateEngine(engineName);

        // Act
        manager.RegisterEngine(engine);

        var result = manager.GetEngine(engineName);

        // Assert
        Assert.Same(engine, result);
    }

    [Fact]
    public void GetEngine_IsCaseInsensitive()
    {
        // Arrange
        var manager = new TemplateEngineManager();
        var engine = new TestTemplateEngine("Liquid");

        manager.RegisterEngine(engine);

        // Act & Assert
        Assert.Same(engine, manager.GetEngine("liquid"));
        Assert.Same(engine, manager.GetEngine("LIQUID"));
    }

    [Fact]
    public void RegisterEngine_SameName_OverwritesPrevious()
    {
        // Arrange
        var manager = new TemplateEngineManager();
        var first = new TestTemplateEngine("liquid");
        var second = new TestTemplateEngine("LIQUID");

        // Act
        manager.RegisterEngine(first);
        manager.RegisterEngine(second);

        var result = manager.GetEngine("liquid");

        // Assert
        Assert.Same(second, result);
    }

    [Fact]
    public void GetEngine_UnknownName_ReturnsNull()
    {
        // Arrange
        var manager = new TemplateEngineManager();

        // Act
        var result = manager.GetEngine("unknown");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void GetAllEngines_ReturnsAllRegisteredEngines()
    {
        // Arrange
        var manager = new TemplateEngineManager();
        var liquid = new TestTemplateEngine("liquid");
        var razor = new TestTemplateEngine("razor");

        manager.RegisterEngine(liquid);
        manager.RegisterEngine(razor);

        // Act
        var all = manager.GetAllEngines();

        // Assert
        Assert.Contains(liquid, all);
        Assert.Contains(razor, all);
        Assert.Equal(2, all.Count());
    }
}
