using System;
using hmgm.UnityLocalize.Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace hmgm.UnityLocalize.UI
{
    [RequireComponent(typeof(Text))]
    public class TextLocalizeScriptable : MonoBehaviour
    {
        [SerializeField]
        private LocalizeTextScriptableObject scriptableObject;

        private Text text;

        private void Start()
        {
            text = GetComponent<Text>();
            text.text = scriptableObject.GetLocalizeText();
        }
    }
}