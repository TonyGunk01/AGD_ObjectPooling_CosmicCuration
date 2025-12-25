using CosmicCuration.Audio;
using CosmicCuration.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.UI
{
    public class DifficultySettingController
    {
        private DifficultySettingView UIView;

        public DifficultySettingController(DifficultySettingView difficultySettingView)
        {
            UIView = difficultySettingView;
            UIView.SetController(this);
        }

        public void DisableView() => UIView.gameObject.SetActive(false);

        public void EnableView() => UIView.gameObject.SetActive(true);

        public void OnClickEasyBtn()
        {
            GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
            GameService.Instance.DifficultyService.currentDifficultyState = DifficultyState.Easy;
        }

        public void OnClickMediumBtn()
        {
            GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
            GameService.Instance.DifficultyService.currentDifficultyState = DifficultyState.Medium;
        }

        public void OnClickHardBtn()
        {
            GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
            GameService.Instance.DifficultyService.currentDifficultyState = DifficultyState.Hard;
        }

        public void OnClickBackBtn()
        {
            DisableView();
            GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
            GameService.Instance.UIService.EnableOptionsScreen();
        }
    }

}
