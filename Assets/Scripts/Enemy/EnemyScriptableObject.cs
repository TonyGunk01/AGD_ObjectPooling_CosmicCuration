using System;
using UnityEngine;

namespace CosmicCuration.Enemy
{
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/EnemySO")]
    public class EnemyScriptableObject : ScriptableObject
    {
        public float spawnDistance;
        public float initialSpawnRate;
        public float minimumSpawnRate;
        public float difficultyDelta;
        public EnemyData enemyData;
    }

    [Serializable]
    public struct EnemyData
    {
        public int maxHealth;
        public float minimumSpeed;
        public float maximumSpeed;
        public int damageToInflict;
        public int scoreToGrant;
        public float movementDuration;
        public float rotationSpeed;
        public float rotationTolerance;
    } 
}