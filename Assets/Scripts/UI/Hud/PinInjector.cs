using TMPro;
using UnityEngine;

namespace UI.Hud
{
    public sealed class PinInjector : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private LockedDocument documentWithPin;

        [SerializeField] private string beforeText;
        [SerializeField] private string afterText;

        private void Start()
        {
            text.text = beforeText + documentWithPin.GetPin() + afterText;
        }
    }
}