using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Hud
{
    public sealed class PanelFader : MonoBehaviour
    {
        [SerializeField] private TMP_Text text;
        [SerializeField] private Image panel;
        [SerializeField] private float showTime;
        [SerializeField] private float textFadeTime;
        [SerializeField] private float panelFadeTime;

        private void Start() => StartCoroutine(Sequence());

        private IEnumerator Sequence()
        {
            yield return new WaitForSeconds(showTime);
            yield return FadeCanvasElement(text, textFadeTime);
            yield return FadeCanvasElement(panel, panelFadeTime);
            gameObject.SetActive(false);
        }

        private IEnumerator FadeCanvasElement(Graphic graphic, float duration)
        {
            float elapsed = 0f;
            Color originalColor = graphic.color;

            while (elapsed < duration)
            {
                elapsed += Time.deltaTime;
                float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
                graphic.color = new (originalColor.r, originalColor.g, originalColor.b, alpha);
                yield return null;
            }

            graphic.color = new (originalColor.r, originalColor.g, originalColor.b, 0f);
        }

    }
}