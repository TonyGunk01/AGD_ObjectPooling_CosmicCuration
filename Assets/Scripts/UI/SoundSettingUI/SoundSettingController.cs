using CosmicCuration.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.UI
{
    public class SoundSettingController
    {
        private SoundSettingView UIView;

        public SoundSettingController(SoundSettingView soundSettingView)
        {
            UIView = soundSettingView;
            UIView.SetController(this);
        }

        public void DisableView() => UIView.gameObject.SetActive(false);

        public void EnableView() => UIView.gameObject.SetActive(true);

        public void OnClickSoundBtn()
        {
            GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
            GameService.Instance.SoundService.ToggleGameplaySoundEffectsState();
            bool value = GameService.Instance.SoundService.GetSoundState() == SfxState.Mute ? false : true;
            SetSoundStateIndicatorUI(value);
        }

        public void OnClickMusicBtn()
        {
            GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
            GameService.Instance.SoundService.ToggleBGMState();
            bool value = GameService.Instance.SoundService.GetMusicState() == SfxState.Mute ? false : true;
            SetMusicStateIndicatorUI(value);
        }
 
        public void OnClickBackBtn()
        {
            DisableView();
            GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
            GameService.Instance.UIService.EnableOptionsScreen();
        }

        public void SetSoundStateIndicatorUI(bool value) => UIView.ToggleSoundIndicator(value);

        public void SetMusicStateIndicatorUI(bool value) => UIView.ToggleMusicIndicator(value);
    }
}
