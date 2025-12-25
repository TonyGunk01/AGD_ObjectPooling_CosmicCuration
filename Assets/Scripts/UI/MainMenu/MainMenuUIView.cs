using UnityEngine;
using UnityEngine.UI;

namespace CosmicCuration.UI
{
    public class MainMenuUIView : MonoBehaviour
    {
        [SerializeField] private Button playButton;
        [SerializeField] private Button optionsButton;

        private MainMenuUIController controller;

        private void Awake()
        {
            playButton.onClick.AddListener(PlayButtonClicked);
            optionsButton.onClick.AddListener(OptionsButtonClicked);
        }

        public void SetController(MainMenuUIController controllerToSet) => controller = controllerToSet;

        private void PlayButtonClicked()=>controller.OnClickPlayBtn();

        private void OptionsButtonClicked() => controller.OnClickOptionsBtn();
    }
}
