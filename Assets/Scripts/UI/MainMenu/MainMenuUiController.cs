using CosmicCuration.Audio;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.UI
{
    public class MainMenuUIController
    {
        private MainMenuUIView mainMenuView;

        public MainMenuUIController(MainMenuUIView mainMenuView)
        {
            this.mainMenuView = mainMenuView;
            this.mainMenuView.SetController(this);
        }

        public void DisableView() => mainMenuView.gameObject.SetActive(false);

        public void EnableView() => mainMenuView.gameObject.SetActive(true);

        public void OnClickPlayBtn()
        {
            DisableView();
            GameService.Instance.UIService.StartGameplay();
        }

        public void OnClickOptionsBtn()
        {
            DisableView();
            GameService.Instance.SoundService.PlaySoundEffects(SoundType.ButtonClick);
            GameService.Instance.UIService.EnableOptionsScreen();
        }
    }
}
