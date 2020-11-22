using System;
using System.Collections.Generic;
using hmgm.UnityLocalize.Scriptable;
using UnityEngine;

namespace hmgm.UnityLocalize.Convert
{
    public static class LocalizeCSVConvert
    {
        private const string DefaultColumn = "Default";

        public static Dictionary<string, LocalizeTextData> CSVToDataDictionary(string text)
        {
            var localizeDictionary = new Dictionary<string, LocalizeTextData>();
            var rowTextList = text.Split(new[]{'\r', '\n'});
            var columnNameList = rowTextList[0].Split(',');
            var columnCount = columnNameList.Length;
            var count = rowTextList.Length;
            for (var i = 1; i < count; ++i)
            {
                if (rowTextList[i].Length == 0)
                {
                    continue;
                }
                var data = new LocalizeTextData();
                var textElements = new List<LocalizeTextElement>();
                var valueColumnTextList = rowTextList[i].Split(',');
                if (valueColumnTextList.Length < columnCount)
                {
                    Debug.LogWarning($"LocalizeSheetManager.CreateTextElement パラメータ名の数と値の数が一致しません 行:{i} パラメータ数{columnCount} 値の数{valueColumnTextList.Length}");
                    Debug.LogWarning($"values: {string.Join(",", valueColumnTextList)}");
                    continue;
                }
                for (var j = 1; j < columnCount; ++j)
                {
                    SystemLanguage language;
                    if (!LanguageTryParse(columnNameList[j], out language))
                    {
                        //defaultの場合は
                        if (columnNameList[j].Equals(DefaultColumn))
                        {
                            data.defaultText = valueColumnTextList[j];
                        }
                        continue;
                    }
                    var element = new LocalizeTextElement();
                    element.language = language;
                    element.text = valueColumnTextList[j];
                    textElements.Add(element);
                }
                data.localizeTextList = textElements;
                localizeDictionary.Add(valueColumnTextList[0], data);
            }
            return localizeDictionary;
        }

        /// <summary>
        /// CSVからTextDataのDictionaryに変換
        /// </summary>
        /// <param name="asset"></param>
        /// <returns></returns>
        public static Dictionary<string, LocalizeTextData> CSVToDataDictionary(TextAsset asset)
        {
            return CSVToDataDictionary(asset.text);
        }
        
        private static bool LanguageTryParse(string text, out SystemLanguage language)
        {
            return Enum.TryParse(text, out language) && Enum.IsDefined(typeof(SystemLanguage), language);
        }
    }
}