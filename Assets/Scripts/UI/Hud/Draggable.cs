using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace UI.Hud
{
    public partial class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private const float HALF = 0.5f;

        [Header("Draggable")]
        [SerializeField] private Vector2 size = Vector2.one;
        [SerializeField] protected RectTransform p_rectTransform;
    
        [Space(20)]
        [SerializeField] private UnityEvent onDrag;
        [SerializeField] private UnityEvent onRelease;

        private bool _isInitialized;
        private RectTransform _canvasRectTransform;
        private Canvas _canvas;
        private Vector2 _offset;

        private void Start() => Init();

        public void OnBeginDrag(PointerEventData eventData)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(p_rectTransform, eventData.position,
                eventData.pressEventCamera, out _offset);
        
            onDrag?.Invoke();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_canvasRectTransform, eventData.position,
                    eventData.pressEventCamera, out Vector2 localPoint))
                p_rectTransform.localPosition = localPoint - _offset + size;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            KeepInScreen();
            onRelease?.Invoke();
        }

        private void OnDestroy() => onDrag.RemoveListener(SetOnTop);

        protected void Init()
        {
            if (_isInitialized)
                return;

            _isInitialized = true;
            
            if (p_rectTransform == null)
                p_rectTransform = GetComponent<RectTransform>();

            _canvas = FindFirstObjectByType<Canvas>();
            _canvasRectTransform = _canvas.GetComponent<RectTransform>();
            
            onDrag.AddListener(SetOnTop);
        }

        protected void SetOnTop() => transform.SetAsLastSibling();

        private void KeepInScreen()
        {
            Vector2 anchoredPos = p_rectTransform.anchoredPosition;
            Vector2 canvasHalfSize = _canvasRectTransform.rect.size * 0.5f;
            Vector2 rectSize = p_rectTransform.rect.size;
            Vector2 rectHalfSize = new (
                rectSize.x * p_rectTransform.pivot.x,
                rectSize.y * p_rectTransform.pivot.y
            );

            float clampedX = Mathf.Clamp(
                anchoredPos.x,
                -canvasHalfSize.x + rectHalfSize.x,
                canvasHalfSize.x - (rectSize.x - rectHalfSize.x)
            );

            float clampedY = Mathf.Clamp(
                anchoredPos.y,
                -canvasHalfSize.y + rectHalfSize.y,
                canvasHalfSize.y - (rectSize.y - rectHalfSize.y)
            );

            p_rectTransform.anchoredPosition = new (clampedX, clampedY);
        }

    }
}
