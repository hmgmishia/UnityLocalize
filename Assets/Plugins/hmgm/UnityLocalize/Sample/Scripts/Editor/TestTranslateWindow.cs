using hmgm.UnityLocalize.Google;
using UnityEditor;
using UnityEngine;

namespace hmgm.UnityLocalize.EditorOnly.Window
{
    public class TestTranslateWindow : EditorWindow
    {
        private static TestTranslateWindow instance;

        private string url;
        private string text;
        private string convertedText;
        private bool isError;

        private SystemLanguage fromLanguage;
        private SystemLanguage toLanguage;

        [MenuItem("Sample/TranslateWindow")]
        private static void Open()
        {
            if (instance != null)
            {
                instance.Show();
            }

            instance = GetWindow<TestTranslateWindow>();
            instance.Show();
        }

        private void OnGUI()
        {
            EditorGUILayout.LabelField(isError ? "error" : "success");
            url = EditorGUILayout.TextField("url", url);
            EditorGUILayout.BeginHorizontal();
            fromLanguage = (SystemLanguage) EditorGUILayout.EnumPopup("from", fromLanguage);
            toLanguage = (SystemLanguage) EditorGUILayout.EnumPopup("to", toLanguage);
            EditorGUILayout.EndHorizontal();

            text = EditorGUILayout.TextArea(text);
            EditorGUI.BeginDisabledGroup(true);
            EditorGUILayout.TextArea(convertedText);
            EditorGUI.EndDisabledGroup();

            if (GUILayout.Button("翻訳"))
            {
                var result = GoogleTranslate.Translate(url, text, fromLanguage, toLanguage);
                convertedText = result.Result;
                isError = result.IsError;
            }
        }
    }
}