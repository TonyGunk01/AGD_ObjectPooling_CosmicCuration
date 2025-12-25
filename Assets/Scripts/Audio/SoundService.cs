using System;
using UnityEngine;

namespace CosmicCuration.Audio
{
    public class SoundService
    {
        private SoundScriptableObject soundScriptableObject;
        private AudioSource audioEffects;
        private AudioSource backgroundMusic;

        private SfxState bgmState;
        private SfxState gameplaySoundEffectsState;

        public SoundService(SoundScriptableObject soundScriptableObject, AudioSource audioEffectSource, AudioSource bgMusicSource)
        {
            this.soundScriptableObject = soundScriptableObject;
            audioEffects = audioEffectSource;
            backgroundMusic = bgMusicSource;
            bgmState = SfxState.Unmute;
            gameplaySoundEffectsState = SfxState.Unmute;
            PlaybackgroundMusic(SoundType.BackgroundMusic, true);
        }

        public void ToggleBGMState()
        {
            bgmState = bgmState == SfxState.Mute ? SfxState.Unmute : SfxState.Mute;

            if (bgmState == SfxState.Mute)
                StopBackgroundMusic(SoundType.BackgroundMusic);
            else
            PlaybackgroundMusic(SoundType.BackgroundMusic);
        }

        public void ToggleGameplaySoundEffectsState() => gameplaySoundEffectsState = gameplaySoundEffectsState == SfxState.Mute ? SfxState.Unmute : SfxState.Mute;

        public SfxState GetSoundState() => gameplaySoundEffectsState;

        public SfxState GetMusicState() => bgmState;
        
        public void PlaySoundEffects(SoundType soundType, bool loopSound = false)
        {
            if (gameplaySoundEffectsState==SfxState.Mute) return;

            AudioClip clip = GetSoundClip(soundType);
            if (clip != null)
            {
                audioEffects.loop = loopSound;
                audioEffects.clip = clip;
                audioEffects.PlayOneShot(clip);
            }
            else
                Debug.LogError("No Audio Clip selected.");
        }

        public void PlaybackgroundMusic(SoundType soundType, bool loopSound = false)
        {
            AudioClip clip = GetSoundClip(soundType);
            if (clip != null)
            {
                backgroundMusic.loop = loopSound;
                backgroundMusic.clip = clip;
                backgroundMusic.Play();
            }
            else
                Debug.LogError("No Audio Clip selected.");
        }

        public void StopBackgroundMusic(SoundType soundType)
        {
            AudioClip clip = GetSoundClip(soundType);
            if (clip != null)
            {
                backgroundMusic.Stop();
            }
            else
                Debug.LogError("No Audio Clip selected.");
        }

        private AudioClip GetSoundClip(SoundType soundType)
        {
            Sounds st = Array.Find(soundScriptableObject.audioList, item => item.soundType == soundType);
            if (st.audio != null)
                return st.audio;
            return null;
        }
    }

    public enum SfxState
    {
        Mute,
        Unmute
    }
}