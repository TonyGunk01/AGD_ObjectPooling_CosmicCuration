using CosmicCuration.PowerUps;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CosmicCuration.UI
{
    public class UIService : MonoBehaviour
    {

        [Header("MainMenu UI:")]
        private MainMenuUIController mainMenuUIController;
        [SerializeField] private MainMenuUIView mainMenuView;

        [Header("Gameplay UI:")]
        private GameplayUIController gameplayUIController;
        [SerializeField] private GameplayUIView gameplayUIView;

        [Header("GameOver UI:")]
        private GameOverUIController gameOverUiController;
        [SerializeField] private GameOverUIView gameOverUIView;

        [Header("Options UI:")]
        private OptionsUIController optionsUIController;
        [SerializeField] private OptionsUIView optionsUIView;
        private SoundSettingController soundSettingController;
        [SerializeField] private SoundSettingView soundSettingView;
        private DifficultySettingController difficultySettingController;
        [SerializeField] private DifficultySettingView difficultySettingView;
        private GameInfoController gameInfoController;
        [SerializeField] private GameInfoView gameInfoView;

        private void Start()
        {
            InitializeController();
            EnableMainMenuUI();
        }

        private void InitializeController()
        {
            mainMenuUIController = new MainMenuUIController(mainMenuView);
            optionsUIController = new OptionsUIController(optionsUIView);
            soundSettingController = new SoundSettingController(soundSettingView);
            difficultySettingController = new DifficultySettingController(difficultySettingView);
            gameInfoController = new GameInfoController(gameInfoView);
            gameplayUIController = new GameplayUIController(gameplayUIView);
            gameOverUiController = new GameOverUIController(gameOverUIView);
        }

        public void EnableMainMenuUI() => mainMenuUIController.EnableView();

        public void EnableGameplayUi() => gameplayUIController.EnableView();

        public void EnableOptionsScreen() => optionsUIController.EnableView();

        public void EnableSoundSettingScreen() => soundSettingController.EnableView();

        public void EnableDifficultySettingScreen() => difficultySettingController.EnableView();

        public void EnableGameInfoScreen() => gameInfoController.EnableView();

        public void EnableGameOverUI() => gameOverUiController.EnableView();

        public void TogglePowerUpUI(bool value, PowerUpType type)
        {
            if (value)
                gameplayUIController.EnablePowerUpUI(type);
            else
                gameplayUIController.DisablePowerUpUI(type);
        }

        public void UpdateScoreUI(int score) => gameplayUIController.ChangeScoreInUI(score);

        public void UpdateHighScoreUI()
        {
            int score = GameService.Instance.PlayerService.GetHighScore();
            gameplayUIController.ChangeHighScoreInUI(score);
        }

        public void UpdateHealthUI(int hp) => gameplayUIController.UpdateHealth(hp);

        public void StartGameplay()
        {
            GameService.Instance.InstantiateGameplayObjects();
            EnableGameplayUi();
            UpdateHighScoreUI();
        }
    }
}