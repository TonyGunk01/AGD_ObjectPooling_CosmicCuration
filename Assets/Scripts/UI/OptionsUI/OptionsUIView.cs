using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CosmicCuration.UI
{
    public class OptionsUIView : MonoBehaviour
    {
        private OptionsUIController controller;

        [SerializeField] private Button SoundSettingBtn;
        [SerializeField] private Button DifficultySettingBtn;
        [SerializeField] private Button GameInfoBtn;
        [SerializeField] private Button backButton;

        private void Awake()
        {
            SoundSettingBtn.onClick.AddListener(SoundSettingBtnClicked);
            DifficultySettingBtn.onClick.AddListener(DifficultySettingBtnClicked);
            GameInfoBtn.onClick.AddListener(GameInfoBtnClicked);
            backButton.onClick.AddListener(BackBtnClicked);
        }

        public void SetController(OptionsUIController controllerToSet) => controller = controllerToSet;

        private void BackBtnClicked()=> controller.OnClickBackBtn();
        
        private void GameInfoBtnClicked()=> controller.OnClcikGameInfoBtn();
        
        private void DifficultySettingBtnClicked()=> controller.OnClickDifficultySettingBtn();
        
        private void SoundSettingBtnClicked()=> controller.OnClickSoundSettingBtn();
    }
}
