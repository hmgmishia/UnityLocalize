using UnityEngine;
using UnityEngine.UI;

namespace hmgm.UnityLocalize.UI
{
    [RequireComponent(typeof(Text))]
    public class TextLocalizeSheet : MonoBehaviour
    {
        [SerializeField]
        private string localizeKey;

        private Text text;

        private void Start()
        {
            text = GetComponent<Text>();
            text.text = LocalizeSheetManager.I.Get(localizeKey);
        }
    }
}