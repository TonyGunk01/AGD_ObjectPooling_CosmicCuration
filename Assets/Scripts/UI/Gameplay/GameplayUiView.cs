using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CosmicCuration.UI
{
    public class GameplayUIView : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;
        [SerializeField] private TMP_Text highScoreText;
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private GameObject rapidFireText;
        [SerializeField] private GameObject doubleTurretText;

        private GameplayUIController controller;

        public void SetController(GameplayUIController controllerToSet) => controller = controllerToSet;

        public void UpdateScoreUI(int scoreToIncrement) => scoreText.text = scoreToIncrement.ToString();

        public void UpdateHighScoreUI(int scoreToIncrement) => highScoreText.text = scoreToIncrement.ToString();

        public void UpdateHealthUI(int healthToDisplay) => healthText.text = healthToDisplay.ToString();

        public void ToggleRapidFireText(bool value) => rapidFireText.SetActive(value);

        public void ToggleDoubleTurretText(bool value) => doubleTurretText.SetActive(value);
        
    }
}
