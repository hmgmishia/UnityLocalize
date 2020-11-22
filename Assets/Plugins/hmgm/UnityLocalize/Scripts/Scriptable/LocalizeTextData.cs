using System;
using System.Collections.Generic;
using UnityEngine;

namespace hmgm.UnityLocalize.Scriptable
{
    [Serializable]
    public class LocalizeTextData
    {
        [SerializeField]
        public string defaultText;

        [SerializeField]
        public List<LocalizeTextElement> localizeTextList;

        /// <summary>
        /// ローカライズしたテキストを取得
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public string GetLocalizeText(SystemLanguage language)
        {
            var text = localizeTextList.Find(x => x.language.Equals(language));
            if (text == null)
            {
                return defaultText;
            }
            return text.text;
        }
    }
}