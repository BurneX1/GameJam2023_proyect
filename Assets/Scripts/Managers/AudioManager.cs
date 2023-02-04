using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Audio;



public class AudioManager : MonoBehaviour
{

    [SerializeField, Range(0.001f, 1f)] private float globalVolume = 0.5f;
    [SerializeField, Range(0.001f, 1f)] private float musicVolume = 0.5f;
    [SerializeField, Range(0.001f, 1f)] private float soundVolume = 0.5f;
    [SerializeField] private Sound[] backgroundMusic;
    [SerializeField] private Sound[] fxMusic;
    [SerializeField] private AudioMixerGroup masterMixer;
    [SerializeField] private AudioMixerGroup backgroundMusicMixer;
    [SerializeField] private AudioMixerGroup soundFxMixer;

    private AudioSource _defaultAudioSource;
    private AudioSource _sndFxAudioSource;
    private readonly Dictionary<string, AudioSource> _audioSources = new Dictionary<string, AudioSource>();
    private readonly Dictionary<string, Sound> _fxSounds = new Dictionary<string, Sound>();

    public void Awake()
    {
        /*if (Instance != null)
        {
            Destroy(gameObject);
        }*/

        /*PlayerPrefUtils.CreateDefaultValue("GenVol", 0.5f);
        PlayerPrefUtils.CreateDefaultValue("MscVol", 0.5f);
        PlayerPrefUtils.CreateDefaultValue("SndVol", 0.5f);*/

        globalVolume = PlayerPrefs.GetFloat("GenVol");

        _sndFxAudioSource = gameObject.AddComponent<AudioSource>();
        _sndFxAudioSource.outputAudioMixerGroup = soundFxMixer;

        foreach (var sound in backgroundMusic)
        {
            var audioSource = GetAudioSource(sound);
            _audioSources.Add(sound.Name, audioSource);
            _defaultAudioSource = audioSource;
        }

        foreach (var fx in fxMusic)
        {
            _fxSounds.Add(fx.Name, fx);
        }
    }

    private AudioSource GetAudioSource(Sound sound)
    {
        var audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = sound.Clip;
        audioSource.volume = sound.Volume;
        audioSource.pitch = sound.Pitch;
        audioSource.loop = sound.Loop;
        audioSource.outputAudioMixerGroup = sound.IsBackgroundMusic ? backgroundMusicMixer : soundFxMixer;
        return audioSource;
    }

    private void Update()
    {
        globalVolume = PlayerPrefs.GetFloat("GenVol");
        musicVolume = PlayerPrefs.GetFloat("MscVol");
        soundVolume = PlayerPrefs.GetFloat("SndVol");
        RefreshVolumes();
    }

    private void RefreshVolumes()
    {
        SetVolume("MasterVol", globalVolume);   //Master Update
        SetVolume("BgmVol", musicVolume);       //BGM Update
        SetVolume("SndVol", soundVolume);       //Snd Update
    }

    private void SetVolume(string volumeKey, float value)
    {
        masterMixer.audioMixer.SetFloat(volumeKey, Mathf.Log10(value) * 20);
    }

    public void PlayBGM(string musicName)
    {
        if (!_audioSources.ContainsKey(musicName))
        {
            Debug.LogError($"Music {musicName} does not exists.");
            return;
        }

        _audioSources[musicName].Play();
    }

    public void PlayFx(string fxName)
    {
        if (!_fxSounds.ContainsKey(fxName))
        {
            Debug.LogError($"Fx {fxName} does not exists.");
            return;
        }

        var clip = _fxSounds[fxName].Clip;
        var volume = _fxSounds[fxName].Volume;
        _sndFxAudioSource.PlayOneShot(clip, volume);
    }

    public void PauseTheme(string musicName)
    {
        if (!_audioSources.ContainsKey(musicName))
        {
            Debug.LogError($"Music {musicName} does not exists.");
            return;
        }

        _audioSources[musicName].Pause();
    }

    public void Stop(string musicName)
    {
        if (!_audioSources.ContainsKey(musicName))
        {
            Debug.LogError($"Music {musicName} does not exists.");
            return;
        }

        _audioSources[musicName].Stop();
    }

    public void ResumeTheme(string musicName)
    {
        if (!_audioSources.ContainsKey(musicName))
        {
            Debug.LogError($"Music {musicName} does not exists.");
            return;
        }

        _audioSources[musicName].UnPause();
    }

    public bool DetectPlaying(string musicName)
    {
        if (_audioSources.ContainsKey(musicName)) return _audioSources[musicName].isPlaying;

        Debug.LogError($"Music {musicName} does not exists.");
        return false;
    }

    public void ChangeVolTo(string musicName, float value, float changeSpd)
    {
        if (!_audioSources.ContainsKey(musicName))
        {
            Debug.LogError($"Music {musicName} does not exists.");
            return;
        }

        var currentVolume = _audioSources[musicName].volume;
        if (Mathf.Approximately(currentVolume, value))
        {
            Debug.LogWarning($"Music {musicName} is already at volume {value}");
            return;
        }

        var sign = -Mathf.Sign(currentVolume - value);
        StartCoroutine(ChangeVol(_audioSources[musicName], value, changeSpd * sign));
    }

    private IEnumerator ChangeVol(AudioSource source, float value, float changeSpd)
    {
        if (value == 0)
        {
            value = 0.001f;
        }
        while (!Mathf.Approximately(source.volume, value))
        {
            source.volume += Time.deltaTime * changeSpd;

            if (Mathf.Approximately(Mathf.Sign(changeSpd), Mathf.Sign(source.volume - value)))
            {
                source.volume = value;
                break;
            }

            yield return null;
        }
    }
}

