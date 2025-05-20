using UnityEngine;

namespace UI.Canvas
{
    public sealed class Window : Draggable
    {
        private bool _hasBeenActive;
        private Vector2 _lastPlace;
        
        public void SetActive(bool target)
        {
            if (!_hasBeenActive)
            {
                _hasBeenActive = true;
                p_rectTransform.position = SetMiddleOfCanvas();
            }
            
            gameObject.SetActive(target);

            if (!target)
                _lastPlace = p_rectTransform.position;
        }
    }
}