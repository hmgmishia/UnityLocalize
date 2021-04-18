using UnityEditor;
using UnityEngine;

namespace hmgm.UnityLocalize.Extensions
{
    public class LocalizeSelectDefineWindow : EditorWindow
    {
        [MenuItem("hmgm/Localize/Localize Select Define Window")]
        private static void ShowWindow()
        {
            var window = GetWindow<LocalizeSelectDefineWindow>();
            window.titleContent = new GUIContent("Localize Select Define Window");
            window.Show();
        }

        private void OnGUI()
        {
        }
    }
}