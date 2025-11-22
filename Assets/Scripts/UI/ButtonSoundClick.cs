using UnityEngine;

public class ButtonSoundClick : ButtonBase
{
    [SerializeField] private AudioSource _audioSource;

    protected override void HandleButtonClick()
    {
        _audioSource.Play();
    }
}
