using System.Collections.Generic;
using UnityEngine;

namespace hmgm.UnityLocalize.Scriptable
{
    [CreateAssetMenu(menuName = "Localize/Text ScriptableObject")]
    public class LocalizeTextScriptableObject : ScriptableObject
    {
        [SerializeField]
        private LocalizeTextData data;

        /// <summary>
        /// ローカライズしたテキストを取得
        /// </summary>
        /// <param name="language"></param>
        /// <returns></returns>
        public string GetLocalizeText(SystemLanguage language)
        {
            return data.GetLocalizeText(language);
        }

        /// <summary>
        /// アプリケーションの言語設定に従いテキストを取得
        /// </summary>
        /// <returns></returns>
        public string GetLocalizeText()
        {
            return data.GetLocalizeText(Application.systemLanguage);
        }

        public LocalizeTextScriptableObject(LocalizeTextData data)
        {
            this.data = data;
        }
    }
   
}