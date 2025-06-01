using UnityEngine;

namespace UI.Hud
{
    public sealed class Window : Hud.Draggable
    {
        [SerializeField] private string windowName = "New window";
        
        private static readonly Vector2 CENTER_SCREEN_OFFSET = new (960, 540);

        private bool _hasBeenActive;
        private Vector2 _lastPlace;
        
        public void SetActive(bool target)
        {
            if (!_hasBeenActive)
            {
                Init();
                _hasBeenActive = true;
                p_rectTransform.position = CENTER_SCREEN_OFFSET;
            }
            
            gameObject.SetActive(target);
            SetOnTop();

            if (!target)
                _lastPlace = p_rectTransform.position;
        }
        
        public void ToggleActive() => SetActive(!gameObject.activeInHierarchy);

        public string GetWindowName() => windowName;
    }
}