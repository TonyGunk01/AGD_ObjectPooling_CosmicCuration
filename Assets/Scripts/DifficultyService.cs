using CosmicCuration.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Player
{
    public class DifficultyService
    {
        private DifficultyController controller;
        public DifficultyState currentDifficultyState;

        public DifficultyService(PlayerScriptableObject playerScriptableObject) => controller = new DifficultyController(currentDifficultyState, playerScriptableObject);

        public PlayerScriptableObject GetDifficultyVariables() => controller.GetDifficultyVariable();
    }

    public enum DifficultyState
    {
        Easy,
        Medium,
        Hard
    }
}
