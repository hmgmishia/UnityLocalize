using System;
using System.IO;
using hmgm.UnityLocalize.Convert;
using hmgm.UnityLocalize.Scriptable;
using UnityEditor;
using UnityEngine;

namespace hmgm.UnityLocalize.Extensions
{
    public class LocalizeCSVToScriptableConvertWindow : EditorWindow
    {
        private string csvPath;
        private string outputUnityPath;
        private bool isExistAssetOverwrite;
    
        [MenuItem("Localize/CSV to Localize ScriptableObject")]
        public static void ShowWindow ()
        {
            GetWindow(typeof(LocalizeCSVToScriptableConvertWindow));
        }

        private void OnGUI()
        {
            isExistAssetOverwrite = EditorGUILayout.Toggle("既にあるファイルを上書き", isExistAssetOverwrite);
            
            EditorGUILayout.BeginHorizontal();
            csvPath = EditorGUILayout.DelayedTextField("CSVパス", csvPath);
            if (GUILayout.Button("開く"))
            {
                csvPath = EditorUtility.OpenFilePanelWithFilters("csvファイルを選択", Application.dataPath, new[] {"CSVファイル", "csv"});
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            outputUnityPath = EditorGUILayout.DelayedTextField("出力先Unityパス", outputUnityPath);
            if (GUILayout.Button("開く"))
            {
                outputUnityPath = EditorUtilityEx.OpenUnityFolderPanel("出力先Unityパスを指定", "");
            }
            EditorGUILayout.EndHorizontal();
            if (GUILayout.Button("出力"))
            {
                Output();
            }
        
        }
    
        private void Output()
        {
            StreamReader reader = new StreamReader(csvPath);
            var localizedictionary = LocalizeCSVConvert.CSVToDataDictionary(reader.ReadToEnd());
            foreach (var dataPair in localizedictionary)
            {
                var path = string.Format("{0}/{1}.asset", outputUnityPath, dataPair.Key);
                if (AssetDatabase.LoadAssetAtPath<LocalizeTextScriptableObject>(path) && !isExistAssetOverwrite)
                {
                    continue;
                }
                var obj = new LocalizeTextScriptableObject(dataPair.Value);
                AssetDatabase.CreateAsset(obj, path);
            }

            EditorUtility.DisplayDialog("出力が完了しました", "出力を完了したため出力先の確認をお願いします", "OK");
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }

}