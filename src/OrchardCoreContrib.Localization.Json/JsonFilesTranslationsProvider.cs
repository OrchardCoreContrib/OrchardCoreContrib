﻿using Microsoft.Extensions.FileProviders;
using OrchardCore.Localization;
using OrchardCoreContrib.Infrastructure;

namespace OrchardCoreContrib.Localization.Json;

/// <summary>
/// Represents a provider that provides a translations for .json files.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="JsonFilesTranslationsProvider"/> class.
/// </remarks>
/// <param name="localizationFileLocationProvider">The <see cref="ILocalizationFileLocationProvider"/>.</param>
public class JsonFilesTranslationsProvider(ILocalizationFileLocationProvider localizationFileLocationProvider) : ITranslationProvider
{
    private readonly JsonReader _jsonReader = new();

    /// <inheritdocs />
    public void LoadTranslations(string cultureName, CultureDictionary dictionary)
    {
        Guard.ArgumentNotNullOrEmpty(cultureName, nameof(cultureName));
        Guard.ArgumentNotNull(dictionary, nameof(dictionary));
        
        foreach (var fileInfo in localizationFileLocationProvider.GetLocations(cultureName))
        {
            LoadFileToDictionaryAsync(fileInfo, dictionary).GetAwaiter().GetResult();
        }
    }

    private async Task LoadFileToDictionaryAsync(IFileInfo fileInfo, CultureDictionary dictionary)
    {
        if (fileInfo.Exists && !fileInfo.IsDirectory)
        {
            using var stream = fileInfo.CreateReadStream();
            using var reader = new StreamReader(stream);
            var cultureRecords = await _jsonReader.ParseAsync(stream);
            dictionary.MergeTranslations(cultureRecords);
        }
    }
}
