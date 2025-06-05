using UnityEngine;
using UnityEngine.Events;

using Framework.Attributes;

namespace Gameplay.Platformer
{
    public sealed class Door : MonoBehaviour
    {
        [SerializeField, Tag] private string playerTag = "Player";
        [SerializeField] private bool isGlitched;
        [SerializeField] private UnityEvent onEnterDoor = new();
        [SerializeField] private UnityEvent onEnterGlitch = new();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(playerTag))
                return;
            
            UnityEvent onEnter = isGlitched ? onEnterGlitch : onEnterDoor;
            onEnter?.Invoke();
        }
    }
}