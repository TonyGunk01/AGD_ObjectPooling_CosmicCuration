using CosmicCuration.Audio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.UI
{
    public class GameInfoController
    {
        private GameInfoView UIView;

        public GameInfoController(GameInfoView gameInfoView)
        {
            UIView = gameInfoView;
            UIView.SetController(this);
        }

        public void DisableView() => UIView.gameObject.SetActive(false);

        public void EnableView() => UIView.gameObject.SetActive(true);

        public void OnClickBackBtn()
        {
            DisableView();
            GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
            GameService.Instance.UIService.EnableOptionsScreen();
        }
    }
}
