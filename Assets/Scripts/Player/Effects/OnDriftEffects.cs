using UnityEngine;

public class OnDriftEffects : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ParticleSystem[] _particleSystems;
    [SerializeField] private TrailRenderer[] _trail;

    private void OnEnable()
    {
        _player.Drifted+=PlayParticles;
        _player.UnDrifted+=StopParticles;
    }

    private void OnDisable()
    {
        _player.Drifted-=PlayParticles;
        _player.UnDrifted-=StopParticles;
    }

    private void PlayParticles() => SetPartical(true);

    private void StopParticles() => SetPartical(false);

    private void SetPartical(bool isPlaying)
    {
        for (int i = 0; i < _particleSystems.Length; i++)
        {
            if (isPlaying)
            {
                _particleSystems[i].Play();
                _trail[i].emitting = true;
            }
            else
            {

                _particleSystems[i].Stop();
                _trail[i].emitting = false;
            }
        }
    }
}
