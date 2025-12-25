using System;
using UnityEngine;
using UnityEngine.UI;

namespace CosmicCuration.UI
{
    public class GameInfoView : MonoBehaviour
    {
        private GameInfoController controller;

        [SerializeField] private Button backButton;

        private void Awake() => backButton.onClick.AddListener(BackBtnClicked);

        public void SetController(GameInfoController controllerToSet) => controller = controllerToSet;

        private void BackBtnClicked() => controller.OnClickBackBtn();
    }
}
