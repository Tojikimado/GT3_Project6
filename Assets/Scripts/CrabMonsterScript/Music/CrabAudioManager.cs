using UnityEngine.Audio;
using System;
using UnityEngine;

public class CrabAudioManager : MonoBehaviour
{

    public Sounds[] sound;

    [SerializeField] private AudioData _audioData;
    [SerializeField] private float _EatingMaxDistance = 10f;
    [SerializeField] private float _EatingMinDistance = 1f;
    [SerializeField] private float _SoundsEffectsMaxDistance = 16f;
    [SerializeField] private float _SoundsEffectsMinDistance = 3f;

    private int _EatingSoundCounter = 0;
    private int _IntimidateSoundCounter = 0;

    void Awake()
    {
        _EatingSoundCounter = 0;
        foreach (Sounds s in sound)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.minDistance = _SoundsEffectsMinDistance;
            s.source.maxDistance = _SoundsEffectsMaxDistance;
            s.source.spatialBlend = 1f;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.isPaused = false;
            if (s.name.Contains("Eating"))
            {
                _EatingSoundCounter++;
                s.source.minDistance = _EatingMinDistance;
                s.source.maxDistance = _EatingMaxDistance;
            } else if (s.name.Contains("Intimidation"))
            {
                _IntimidateSoundCounter++;
            }

        }
    }

    private Sounds GetSound(string name)
    {
        Sounds s = Array.Find(sound, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("sound " + name + " was not found");
            return null;
        }
        return s;
    }

    public void PlayRandomEatingSound()
    {
        int index = UnityEngine.Random.Range(0, _EatingSoundCounter);
        Play("Eating" + index.ToString());
    }
    public void PlayRandomIntimidateSound()
    {
        int index = UnityEngine.Random.Range(0, _IntimidateSoundCounter);
        Play("Intimidation" + index.ToString());
    }

    /// <summary>
    /// Plays the sound, can then be paused or stopped
    /// </summary>
    public void Play(string name)
    {
        Sounds s = GetSound(name);
        if (s.source == null) return;
        if (!_audioData.GetIfSoundIsPlayable(s.soundType)) return;
        s.source.Play();
        s.isPaused = false;
    }

    /// <summary>
    /// Paused the sound if played, Can Be unpaused
    /// </summary>
    public void Pause(string name)
    {
        Sounds s = GetSound(name);
        if (s.source == null) return;
        if (!s.source.isPlaying) return;
        s.source.Pause();
        s.isPaused = true;
    }
    /// <summary>
    /// Can be used to play for the first time or unpause an already played sound
    /// </summary>
    public void UnPause(string name)
    {
        Sounds s = GetSound(name);
        if (s.source == null) return;
        if (s.source.isPlaying && !s.isPaused || !_audioData.GetIfSoundIsPlayable(s.soundType)) return;
        if (s.isPaused)
            s.source.UnPause();
        else
            s.source.Play();
        s.isPaused = false;
    }
    /// <summary>
    /// Used only to play a sond if it has already been played
    /// </summary>
    public void HardUnPause(string name)
    {
        Sounds s = GetSound(name);
        if (s.source == null) return;
        if (s.source.isPlaying && !s.isPaused || !_audioData.GetIfSoundIsPlayable(s.soundType)) return;
        if (s.isPaused)
            s.source.UnPause();
        s.isPaused = false;
    }

    /// <summary>
    /// Stops the sound, can then be played again but from start only
    /// </summary>
    public void Stop(string name)
    {
        Sounds s = GetSound(name);
        if (s.source == null) return;
        s.source.Stop();
        s.isPaused = false;
    }

    public void MuteAllMusics(bool isMuting)
    {
        MuteAllSoundType(SoundType.Music, isMuting);
    }
    public void MuteAllSoundEffects(bool isMuting)
    {
        MuteAllSoundType(SoundType.SoundEffect, isMuting);
    }
    private void MuteAllSoundType(SoundType type, bool isMuting)
    {
        foreach (Sounds s in sound)
        {
            if (s.soundType == type)
                if (isMuting && !s.isPaused)
                    Pause(s.name);
                else if (!isMuting)
                {
                    HardUnPause(s.name);
                }
            if (s.soundType == SoundType.Music && s.name == _audioData.m_CurrentMusic)
            {
                UnPause(s.name);
            }
        }
    }

    
}
