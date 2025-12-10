using UnityEngine;

public class AudioService : MonoBehaviour, IGameService
{
    private AudioSource _musicSource;
    private AudioSource _sfxSource;

    public void Initialize()
    {
        _musicSource = gameObject.AddComponent<AudioSource>();
        _sfxSource = gameObject.AddComponent<AudioSource>();

        _musicSource.loop = true;
        Debug.Log("AudioService initialized.");
    }

    public void Shutdown()
    {
        Debug.Log("AudioService shutdown.");
    }

    public void PlayMusic(AudioClip clip, float volume = 1f)
    {
        _musicSource.clip = clip;
        _musicSource.volume = volume;
        _musicSource.Play();
    }

    public void PlaySFX(AudioClip clip, float volume = 1f)
    {
        _sfxSource.PlayOneShot(clip, volume);
    }

    public void StopMusic()
    {
        _musicSource.Stop();
    }
}