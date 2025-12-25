using CosmicCuration.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CosmicCuration.Player
{
    public class DifficultyController
    {
        private PlayerScriptableObject playerScriptableObject;
        public DifficultyController(DifficultyState difficultyState, PlayerScriptableObject playerScriptable) => SetDifficultyState(difficultyState, playerScriptable);

        private void SetDifficultyState(DifficultyState difficultyState, PlayerScriptableObject playerScriptableObject)
        {
            this.playerScriptableObject = playerScriptableObject;
            
            switch (difficultyState)
            {
                case DifficultyState.Easy:
                    playerScriptableObject.movementSpeed = 3;
                    break;

                case DifficultyState.Medium:
                    playerScriptableObject.movementSpeed = 5;
                    break;

                case DifficultyState.Hard:
                    playerScriptableObject.movementSpeed = 7;
                    break;

                default:
                    playerScriptableObject.movementSpeed = 3;
                    break;
            }

            this.playerScriptableObject = playerScriptableObject;
        }

        public PlayerScriptableObject GetDifficultyVariable() => playerScriptableObject;
        
    }
}