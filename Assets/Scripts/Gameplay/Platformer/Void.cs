using UnityEngine;

using Framework.Attributes;

namespace Gameplay.Platformer
{
    public sealed class Void : MonoBehaviour
    {
        [SerializeField, Tag] private string playerTag = "Player";
        [SerializeField] private Transform resetTransform;

        private void Awake()
        {
            if (TryGetComponent(out SpriteRenderer component))
                component.sprite = null;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag(playerTag))
                return;

            other.transform.position = resetTransform.position;
        }
    }
}