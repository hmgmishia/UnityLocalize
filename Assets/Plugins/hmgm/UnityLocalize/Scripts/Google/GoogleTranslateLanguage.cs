using System.Collections.Generic;
using UnityEngine;

namespace hmgm.UnityLocalize.Google
{
    public class GoogleTranslateLanguage
    {
        private static readonly Dictionary<SystemLanguage, string> Languages = new Dictionary<SystemLanguage, string>()
        {
            {SystemLanguage.Afrikaans, "af"},
            {SystemLanguage.Arabic, "ar"},
            {SystemLanguage.Basque, "ba"},
            {SystemLanguage.Belarusian, "be"},
            {SystemLanguage.Catalan, "ca"},
            {SystemLanguage.Chinese, "zh-CN"},
            {SystemLanguage.ChineseSimplified, "zh-TN"},
            {SystemLanguage.ChineseTraditional, "zh-CN"},
            {SystemLanguage.Czech, "cz"},
            {SystemLanguage.Danish, "da"},
            {SystemLanguage.Dutch, "du"},
            {SystemLanguage.English, "en"},
            {SystemLanguage.Estonian, "es"},
            {SystemLanguage.Faroese, "fa"},
            {SystemLanguage.Finnish, "fi"},
            {SystemLanguage.French, "fr"},
            {SystemLanguage.German, "ge"},
            {SystemLanguage.Greek, "gr"},
            {SystemLanguage.Hebrew, "he"},
            {SystemLanguage.Hungarian, "hu"},
            {SystemLanguage.Icelandic, "ic"},
            {SystemLanguage.Indonesian, "in"},
            {SystemLanguage.Italian, "it"},
            {SystemLanguage.Japanese, "ja"},
            {SystemLanguage.Korean, "ko"},
            {SystemLanguage.Latvian, "la"},
            {SystemLanguage.Lithuanian, "li"},
            {SystemLanguage.Norwegian, "no"},
            {SystemLanguage.Polish, "pl"},
            {SystemLanguage.Portuguese, "pt"},
            {SystemLanguage.Romanian, "ro"},
            {SystemLanguage.Russian, "ru"},
            {SystemLanguage.SerboCroatian, "se"},
            {SystemLanguage.Slovak, "sk"},
            {SystemLanguage.Slovenian, "sl"},
            {SystemLanguage.Spanish, "sp"},
            {SystemLanguage.Swedish, "sw"},
            {SystemLanguage.Thai, "th"},
            {SystemLanguage.Turkish, "tu"},
            {SystemLanguage.Ukrainian, "uk"},
            {SystemLanguage.Vietnamese, "vi"},
            {SystemLanguage.Unknown, "auto"}
        };

        public static string GetLanguage(SystemLanguage lang)
        {
            return Languages[lang];
        }
    }
}