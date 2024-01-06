using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioClip[] _sound;

    public void PlaySound(int id)
    {
        _soundSource.PlayOneShot(_sound[id]);
    }

    //public float GetMusicVolume()
    //{
    //    return _musicSource.volume;
    //}

    //public float GetSoundVolume()
    //{
    //    return _soundSource.volume;
    //}
}
