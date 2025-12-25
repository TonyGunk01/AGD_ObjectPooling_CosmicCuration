using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CosmicCuration.UI
{
    public class DifficultySettingView : MonoBehaviour
    {
        private DifficultySettingController controller;

        [SerializeField] private Button easyBtn;
        [SerializeField] private Button mediumBtn;
        [SerializeField] private Button hardBtn;
        [SerializeField] private Button backButton;

        private void Awake()
        {
            easyBtn.onClick.AddListener(EasyBtnClicked);
            mediumBtn.onClick.AddListener(MediumBtnClicked);
            hardBtn.onClick.AddListener(HardBtnClicked);
            backButton.onClick.AddListener(BackBtnClicked);
        }

        public void SetController(DifficultySettingController controllerToSet) => controller = controllerToSet;

        private void BackBtnClicked() => controller.OnClickBackBtn();

        private void HardBtnClicked() => controller.OnClickHardBtn();

        private void MediumBtnClicked() => controller.OnClickMediumBtn();

        private void EasyBtnClicked() => controller.OnClickEasyBtn();
    }
}
