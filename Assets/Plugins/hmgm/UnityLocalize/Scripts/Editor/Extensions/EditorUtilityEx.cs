using UnityEditor;
using UnityEngine;

namespace hmgm.UnityLocalize.Extensions
{
    public static class EditorUtilityEx
    {
        public static string OpenUnityFolderPanel(string title, string defaultName)
        {
            var path = EditorUtility.OpenFolderPanel(title, Application.dataPath, defaultName);
            if (!path.Contains(Application.dataPath))
            {
                return "";
            }
            return path.Replace(Application.dataPath, "Assets");
        }
    }
}