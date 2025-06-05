using System;
using TMPro;
using UnityEngine;

namespace UI.Hud
{
    public class Window : Draggable
    {
        [SerializeField] private string windowName = "New window";
        [SerializeField] private TMP_Text windowLabel;
        [SerializeField] private Sprite icon;
        
        private static readonly Vector2 CENTER_SCREEN_OFFSET = new (960, 540);

        private bool _hasBeenActive;
        private Vector2 _lastPlace;

        protected virtual void Awake()
        {
            windowLabel.text = windowName;
        }

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
        
        public void SetWindowName(string name)
        {
            windowName = name;
            windowLabel.text = windowName;
        }

        public Sprite GetWindowIcon() => icon;
    }
}