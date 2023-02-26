using UnityEngine;
using System;

[CreateAssetMenu (menuName ="Data/Crab/Sounds")]
public class AudioData : ScriptableObject
{
    [SerializeField]
    private Audio[] audioClip;
    public Audio[] AudioClip { get { return audioClip; } }

    public string m_CurrentMusic = "Remix";
    public void ResetAllAudioData()
    {
        audioClip = new Audio[Enum.GetValues(typeof(SoundType)).Length];
        foreach (SoundType type in Enum.GetValues(typeof(SoundType)))
        {
            audioClip[(int) type] = new Audio(type);
        }
        CheckSize();
    }

    public void SetCurrentMusic(string currentMusic)
    {
        m_CurrentMusic = currentMusic;
    }

    private void CheckSize()
    {
        if (audioClip == null || audioClip.Length == 0 || audioClip.Length < Enum.GetValues(typeof(SoundType)).Length)
        {
            Debug.LogError("Update AudioData values in Asset/Data/Audio Data => Update");
        }
    }
    public void SetIfPlayableSoundType(SoundType type, bool isPlayable)
    {
        CheckSize();
        audioClip[(int)type].CanPlay = isPlayable;
    }
    public void SetAudioClipsParams(Audio[] audioParams)
    {
        audioClip = audioParams;
    }
    
    public void SetIfMusicIsPlayable(bool isPlayable)
    {
        SetIfPlayableSoundType(SoundType.Music, isPlayable);
        // MuteAllMusics(!isPlayable);
    }
    public void SetIfSoundEffectIsPlayable(bool isPlayable)
    {
        SetIfPlayableSoundType(SoundType.SoundEffect, isPlayable);
        // MuteAllSoundEffects(!isPlayable);
    }

    public bool GetIfSoundIsPlayable(SoundType type)
    {
        CheckSize();
        return audioClip[(int)type].CanPlay;
    }
}

[System.Serializable]
public class Audio
{
    public SoundType Type;
    public bool CanPlay = true;
    public Audio(SoundType type)
    {
        Type = type;
    }
}