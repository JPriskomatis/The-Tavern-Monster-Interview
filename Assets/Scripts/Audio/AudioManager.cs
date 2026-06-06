using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [System.Serializable]
    public class Sound
    {
        public string soundName;
        public AudioClip clip;

        [Range(0f, 1f)]
        public float volume = 1f;

        [Range(0.1f, 3f)]
        public float pitch = 1f;

        public bool loop = false;

        [HideInInspector]
        public AudioSource source;
    }

    [Header("Audio List")]
    public Sound[] sounds;

    private Dictionary<string, Sound> soundDictionary;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        soundDictionary = new Dictionary<string, Sound>();

        foreach (Sound sound in sounds)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();

            source.clip = sound.clip;
            source.volume = sound.volume;
            source.pitch = sound.pitch;
            source.loop = sound.loop;

            sound.source = source;

            if (!soundDictionary.ContainsKey(sound.soundName))
                soundDictionary.Add(sound.soundName, sound);
        }
    }

    public void Play(string soundName)
    {
        if (soundDictionary.TryGetValue(soundName, out Sound sound))
        {
            sound.source.Play();
        }
        else
        {
            Debug.LogWarning($"Sound '{soundName}' not found.");
        }
    }

    public void Stop(string soundName)
    {
        if (soundDictionary.TryGetValue(soundName, out Sound sound))
        {
            sound.source.Stop();
        }
    }

    public void Pause(string soundName)
    {
        if (soundDictionary.TryGetValue(soundName, out Sound sound))
        {
            sound.source.Pause();
        }
    }

    public void UnPause(string soundName)
    {
        if (soundDictionary.TryGetValue(soundName, out Sound sound))
        {
            sound.source.UnPause();
        }
    }

    public bool IsPlaying(string soundName)
    {
        if (soundDictionary.TryGetValue(soundName, out Sound sound))
        {
            return sound.source.isPlaying;
        }

        return false;
    }

    public void SetVolume(string soundName, float volume)
    {
        if (soundDictionary.TryGetValue(soundName, out Sound sound))
        {
            sound.source.volume = volume;
        }
    }

    public void PlayOneShot(AudioClip clip, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }
}