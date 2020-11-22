using System;
using System.Collections.Generic;
using hmgm.UnityLocalize.Convert;
using hmgm.UnityLocalize.Scriptable;
using UnityEngine;

namespace hmgm.UnityLocalize
{
    /// <summary>
    /// CSVの内容をもとにローカライズを行うクラス
    /// </summary>
    public class LocalizeSheetManager
    {
        private const string ResourcePath = "Localize/Localize";

        /// <summary>
        /// ローカライズデータ
        /// </summary>
        private Dictionary<string, LocalizeTextData> localizeDictionary;
        
        private static LocalizeSheetManager instance;
        public static LocalizeSheetManager I
        {
            get
            {
                if (instance == null)
                {
                    instance = new LocalizeSheetManager();
                }
                return instance;
            }
        }

        private LocalizeSheetManager()
        {
            localizeDictionary = LocalizeCSVConvert.CSVToDataDictionary(Resources.Load<TextAsset>(ResourcePath));
        }

        /// <summary>
        /// Keyに合ったローカライズテキストを取得
        /// </summary>
        /// <param name="key"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        public string Get(string key, SystemLanguage language)
        {
            if (!localizeDictionary.ContainsKey(key))
            {
                Debug.LogWarning($"LocalizeSheetManager.Get Keyが存在しません key:{key}");
                return "";
            }
            return localizeDictionary[key].GetLocalizeText(language);
        }

        /// <summary>
        /// アプリの言語設定に従いKeyに合ったローカライズテキストを取得
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Get(string key)
        {
            if (!localizeDictionary.ContainsKey(key))
            {
                Debug.LogWarning($"LocalizeSheetManager.Get Keyが存在しません key:{key}");
                return "";
            }
            return localizeDictionary[key].GetLocalizeText(Application.systemLanguage);
        }
    }
}