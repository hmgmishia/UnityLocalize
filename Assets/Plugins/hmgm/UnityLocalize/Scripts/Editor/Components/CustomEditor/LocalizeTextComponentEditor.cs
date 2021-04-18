using hmgm.UnityLocalize.Components;
using UnityEditor;
using UnityEngine;

namespace hmgm.UnityLocalize.Extensions
{
    [CustomEditor(typeof(LocalizeUGUITextComponent))]
    public class LocalizeTextComponentEditor : Editor
    {
        private Object localizeScriptableObject;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
        }
    }
}