using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioClip[] _sound; 

    public void PlaySound(int id)
    {
        _soundSource.PlayOneShot(_sound[id]);
    }
}
