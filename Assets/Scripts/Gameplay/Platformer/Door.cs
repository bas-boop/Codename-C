using UnityEngine;
using UnityEngine.Events;

using Framework.Attributes;

namespace Gameplay.Platformer
{
    public sealed class Door : MonoBehaviour
    {
        private readonly Vector3 UPSIDEDOWN_SCALE = new(1, -1, 1);
        
        [SerializeField, Tag] private string playerTag = "Player";
        [SerializeField] private bool isGlitched;
        [SerializeField] private UnityEvent onEnterDoor = new();
        [SerializeField] private UnityEvent onEnterGlitch = new();

        private void Awake()
        {
            if (isGlitched)
                transform.localScale = UPSIDEDOWN_SCALE; // temp until art
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(playerTag))
                return;
            
            UnityEvent onEnter = isGlitched ? onEnterGlitch : onEnterDoor;
            onEnter?.Invoke();
        }
    }
}