using UnityEngine;

using Framework.Data;

namespace UI
{
    public sealed class MainMenu : MonoBehaviour
    {
        private void Start() => GameplayData.Instance.DeleteSavedWindows();

        public void OpenUrl(string url) => Application.OpenURL(url);

        public void Quit() => Application.Quit();
    }
}