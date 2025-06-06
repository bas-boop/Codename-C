using UnityEngine;

namespace UI
{
    public sealed class MainMenu : MonoBehaviour
    {
        public void OpenUrl(string url) => Application.OpenURL(url);

        public void Quit() => Application.Quit();
    }
}