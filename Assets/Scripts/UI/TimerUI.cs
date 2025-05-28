using UnityEngine;
using TMPro;

using Framework;

namespace UI
{
    public sealed class TimerUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Timer timer;

        private bool _isShowing;

        private void Awake() => text.gameObject.SetActive(false);

        private void Update()
        {
            if (!timer.IsCounting)
                return;

            if (timer.GetCurrentTime() <= 9.99f)
            {
                text.text = 0 + timer.GetCurrentTime().ToString("F2");
                return;
            }
            
            text.text = timer.GetCurrentTime().ToString("F2");
        }
    }
}