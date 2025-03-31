using OrchardCore.ContentManagement.Metadata.Builders;
using OrchardCoreContrib.ContentManagement.Tests;

namespace OrchardCoreContrib.ContentManagement.Helpers.Tests;

public static class ContentPartFieldDefinitionBuilderHelper
{

    public static ContentPartFieldDefinitionBuilder CreateDummyPartFieldDefinitionBuilder()
    {
        var partDefinition = new ContentPartDefinitionBuilder()
            .Named("SomePart")
            .WithField("SomeField")
            .Build();

        return new ContentPartFieldDefinitionBuilderImpl(partDefinition.Fields.First(), partDefinition);
    }
}
