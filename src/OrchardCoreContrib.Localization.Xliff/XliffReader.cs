﻿using OrchardCore.Localization;
using OrchardCoreContrib.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OrchardCoreContrib.Localization.Xliff;

/// <summary>
/// Represents an XLIFF reader.
/// </summary>
public class XliffReader
{
    /// <summary>
    /// Parses a given XLIFF file.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> to be parsed.</param>
    /// <exception cref="XliffException"></exception>
    public static async Task<IEnumerable<CultureDictionaryRecord>> ParseAsync(Stream stream)
    {
        Guard.ArgumentNotNull(stream, nameof(stream));

        try
        {
            var cultureRecords = new List<CultureDictionaryRecord>();
            var document = await XDocument.LoadAsync(stream, LoadOptions.None, CancellationToken.None);
            
            var version = document.Root.Attribute("version").Value;           
            switch (version)
            {
                case "2.0":
                    cultureRecords.AddRange(ReadXliff2_0(document));
                    break;
                case "1.2":
                case "1.1":
                    cultureRecords.AddRange(ReadXliff1_0(document));
                    break;
                default:
                    throw new NotSupportedException($"Xliff with a version '{version}' is not supported.");
            }

            return cultureRecords;
        }
        catch (Exception ex)
        {
            throw new XliffException("Invalid XLIFF document.", ex);
        }
    }

    private static IEnumerable<CultureDictionaryRecordWrapper> ReadXliff2_0(XDocument document)
    {
        var @namespace = document.Root.Name.Namespace;
        foreach (var unitElement in document.Descendants(@namespace + "unit"))
        {
            var segmentElement = unitElement.Element(@namespace + "segment");
            var key = segmentElement.Element(@namespace + "source").Value;
            var value = segmentElement.Element(@namespace + "target").Value;

            yield return new CultureDictionaryRecordWrapper(key, value);
        }
    }

    private static IEnumerable<CultureDictionaryRecordWrapper> ReadXliff1_0(XDocument document)
    {
        var @namespace = document.Root.Name.Namespace;
        foreach (var unitElement in document.Descendants(@namespace + "trans-unit"))
        {
            var key = unitElement.Element(@namespace + "source").Value;
            var value = unitElement.Element(@namespace + "target").Value;

            yield return new CultureDictionaryRecordWrapper(key, value);
        }
    }
}
