using UnityEngine;
using UnityEngine.UI;

using Framework.Data;

namespace UI.Hud
{
    public class SoundButton : Button
    {
        private AudioSource _audioSource;
        
        protected override void Awake()
        {
            base.Awake();
            
            if (!GameplayData.Exist)
                return;
            
            _audioSource = gameObject.AddComponent<AudioSource>();
            onClick.AddListener(AddSoundToOnClick);
        }

        private void AddSoundToOnClick()
        {
            AudioClip[] click = GameplayData.Instance.GetClips();
            _audioSource.clip = click[Random.Range(0, click.Length)];
            _audioSource.Play();
        }
    }
}