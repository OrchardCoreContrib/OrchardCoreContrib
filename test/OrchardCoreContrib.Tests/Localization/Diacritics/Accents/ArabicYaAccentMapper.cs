﻿using System.Collections.Generic;
using System.Globalization;

namespace OrchardCoreContrib.Localization.Diacritics.Tests
{
    public class ArabicYaAccentMapper : IAccentMapper
    {
        public CultureInfo Culture => CultureInfo.GetCultureInfo("ar");

        public IDictionary<char, string> Mapping => new Dictionary<char, string>
        {
            { 'ئ', "ي" },
            { 'ى', "ي" }
        };
    }
}
