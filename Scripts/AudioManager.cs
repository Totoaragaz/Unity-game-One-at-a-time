using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
///FindObjectOfType<AudioManager>().Play("");
public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;
    public Sound Music;
    public float MusicVolume;
    public float SFXVolume;

	void Awake()
	{
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.25f);
            SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0.25f);
            DontDestroyOnLoad(gameObject);
        }

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

    void Start()
    {
        Music.source = gameObject.AddComponent<AudioSource>();
        Music.source.clip = Music.clip;
        Music.source.loop = Music.loop;

        Music.source.outputAudioMixerGroup = mixerGroup;
        Music.source.volume = Music.volume * MusicVolume;
        
        Music.source.pitch = Music.pitch * (1f + UnityEngine.Random.Range(-Music.pitchVariance / 2f, Music.pitchVariance / 2f));
        
        Music.source.Play();
    }

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}
        s.source.volume = s.volume * SFXVolume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));

		s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}

    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (MusicVolume != PlayerPrefs.GetFloat("MusicVolume", 0.25f))
            {
                MusicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.25f);
                Music.source.volume = Music.volume * MusicVolume;
            }
            SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 0.25f);
        }
    }
}
