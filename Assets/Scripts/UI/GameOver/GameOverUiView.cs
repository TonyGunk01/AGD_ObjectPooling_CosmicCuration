using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace CosmicCuration.UI
{
    public class GameOverUIView : MonoBehaviour
    {
        private GameOverUIController controller;

        [SerializeField] private Button playAgainButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text highScoreText;

        public void SetController(GameOverUIController controllerToSet) => controller = controllerToSet;

        private void OnEnable()
        {
            playAgainButton.onClick.AddListener(PlayAgainClicked);
            quitButton.onClick.AddListener(QuitClicked);
            scoreText.text = GameService.Instance.PlayerService.GetCurrentScore().ToString();
            highScoreText.text = GameService.Instance.PlayerService.GetHighScore().ToString();
        }

        private void PlayAgainClicked() => controller.OnPlayAgainClicked();

        private void QuitClicked() => controller.OnQuitClicked();
    }
}
