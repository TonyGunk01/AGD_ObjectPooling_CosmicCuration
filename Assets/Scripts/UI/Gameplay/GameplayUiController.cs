using CosmicCuration.PowerUps;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.UI
{
    public class GameplayUIController
    {
        private GameplayUIView gameplayUiView;

        public GameplayUIController(GameplayUIView gameplayUiView)
        {
            this.gameplayUiView = gameplayUiView;
            this.gameplayUiView.SetController(this);
        }

        public void DisableView() => gameplayUiView.gameObject.SetActive(false);

        public void EnableView() => gameplayUiView.gameObject.SetActive(true);

        public void UpdateHealth(int healthToDisplay) => gameplayUiView.UpdateHealthUI(healthToDisplay);

        public void EnablePowerUpUI(PowerUpType powerUpType)
        {
            switch (powerUpType)
            {
                case PowerUpType.RapidFire:
                    gameplayUiView.ToggleRapidFireText(true);
                    break;
                case PowerUpType.DoubleTurret:
                    gameplayUiView.ToggleDoubleTurretText(true);
                    break;
            }
        }

        public void DisablePowerUpUI(PowerUpType powerUpType)
        {
            switch (powerUpType)
            {
                case PowerUpType.RapidFire:
                    gameplayUiView.ToggleRapidFireText(false);
                    break;
                case PowerUpType.DoubleTurret:
                    gameplayUiView.ToggleDoubleTurretText(false);
                    break;
            }
        }

        public void ChangeScoreInUI(int score) => gameplayUiView.UpdateScoreUI(score);

        public void ChangeHighScoreInUI(int score) => gameplayUiView.UpdateHighScoreUI(score);
    }
}
