using UnityEngine;
using UnityEngine.Events;

using Framework.Attributes;

namespace Gameplay.Platformer
{
    public sealed class Coin : MonoBehaviour
    {
        [SerializeField, Tag] private string playerTag = "Player";
        [SerializeField] private UnityEvent onCollect = new();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(playerTag))
                return;
            
            onCollect?.Invoke();
            gameObject.SetActive(false);
        }
    }
}