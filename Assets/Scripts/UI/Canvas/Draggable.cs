using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UI.Canvas
{
    public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private const float HALF = 0.5f;
        private const float SCALE = 110;

        [Header("Draggable")]
        [SerializeField] private Vector2 size = Vector2.one;
    
        [Space(20)]
        [SerializeField] private UnityEvent onDrag;
        [SerializeField] private UnityEvent onRelease;
    
        private RectTransform _rectTransform;
        private RectTransform _canvasRectTransform;
        private UnityEngine.Canvas _canvas;
        private Vector2 _offset;
        private Vector2 _size;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _canvas = GetComponentInParent<UnityEngine.Canvas>();
            _canvasRectTransform = _canvas.GetComponent<RectTransform>();
            _size = size * SCALE;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(_rectTransform, eventData.position,
                eventData.pressEventCamera, out _offset);
        
            onDrag?.Invoke();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRectTransform, eventData.position,
                    eventData.pressEventCamera, out Vector2 localPoint))
                _rectTransform.localPosition = localPoint - _offset;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            KeepInScreen();
            onRelease?.Invoke();
        }

        private void KeepInScreen()
        {
            Vector2 anchoredPos = _rectTransform.anchoredPosition;

            Vector2 canvasHalfSize = _canvasRectTransform.rect.size * HALF;
            Vector2 rectHalfSize = new (
                _size.x * _rectTransform.pivot.x,
                _size.y * _rectTransform.pivot.y
            );

            float clampedX = Mathf.Clamp(
                anchoredPos.x,
                -canvasHalfSize.x + rectHalfSize.x,
                canvasHalfSize.x - (_size.x - rectHalfSize.x)
            );

            float clampedY = Mathf.Clamp(
                anchoredPos.y,
                -canvasHalfSize.y + rectHalfSize.y,
                canvasHalfSize.y - (_size.y - rectHalfSize.y)
            );
        
            _rectTransform.anchoredPosition = new (clampedX, clampedY);
        }
    }
}
