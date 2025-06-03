using UnityEngine;
using TMPro;

namespace UI.Hud
{
    public sealed class ExposedDocumentsUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;

        private void Awake() => text.text = string.Empty;

        public void UpdateText(DocumentData[] uploads)
        {
            string updatedText = null;

            for (int i = 0; i < uploads.Length; i++)
            {
                DocumentData upload = uploads[i];
                updatedText += $"{i + 1} - {upload.name}\n";
            }

            text.text = updatedText;
        }
    }
}