using CosmicCuration.Bullets;
using UnityEngine;

namespace CosmicCuration.Player
{
    public class PlayerService
    {
        private PlayerController playerController;

        private int currentScore;
        private int highScore;

        public PlayerService(PlayerView playerViewPrefab, PlayerScriptableObject playerScriptableObject, BulletView bulletPrefab, BulletScriptableObject bulletScriptableObject)=> playerController = new PlayerController(playerViewPrefab, playerScriptableObject, bulletPrefab, bulletScriptableObject);
        
        public PlayerController GetPlayerController() => playerController;

        public Vector3 GetPlayerPosition() => playerController.GetPlayerPosition();

        public int GetCurrentScore() => currentScore;

        public void UpdateScoreValue(int score)
        {
            currentScore += score;
            GameService.Instance.UIService.UpdateScoreUI(currentScore);

            if (currentScore > highScore)
            {
                highScore = currentScore;
                PlayerPrefs.SetInt("HighScore", highScore);
            }
        }

        public int GetHighScore()
        {
            if (PlayerPrefs.HasKey("HighScore"))
                highScore = PlayerPrefs.GetInt("HighScore");

            if (currentScore > highScore)
                highScore = currentScore;

            return highScore;
        }
    }
}