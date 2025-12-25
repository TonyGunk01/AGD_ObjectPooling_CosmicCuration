using UnityEngine;
using TMPro;
using CosmicCuration.Audio;
using CosmicCuration.Enemy;
using CosmicCuration.Bullets;
using CosmicCuration.VFX;
using CosmicCuration.Player;
using CosmicCuration.UI;
using CosmicCuration.Utilities;
using CosmicCuration.PowerUps;


public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService PlayerService { get; private set; }
    public EnemyService EnemyService { get; private set; }
    public DifficultyService DifficultyService { get; private set; }
    public PowerUpService PowerUpService { get; private set; }
    public VFXService VfxService { get; private set; }
    public SoundService SoundService { get; private set; }
    public UIService UIService { get { return uiService; } }

    [SerializeField] private UIService uiService;

    [SerializeField] private PlayerView playerPrefab;
    [SerializeField] private BulletView playerBulletPrefab;
    [SerializeField] private EnemyView enemyPrefab;

    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private BulletScriptableObject playerBulletScriptableObject;
    [SerializeField] private EnemyScriptableObject enemyScriptableObject;
    [SerializeField] private PowerUpScriptableObject powerUpScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private VFXScriptableObject vfxScriptableObject;
 
    [SerializeField] private AudioSource audioEffectSource;
    [SerializeField] private AudioSource backgroundMusicSource;

    private void Start()
    {
        SoundService = new SoundService(soundScriptableObject, audioEffectSource, backgroundMusicSource);
        DifficultyService = new DifficultyService(playerScriptableObject);
    }

    public void InstantiateGameplayObjects()
    {
        playerScriptableObject = DifficultyService.GetDifficultyVariables();
        
        PlayerService = new PlayerService(playerPrefab, playerScriptableObject, playerBulletPrefab, playerBulletScriptableObject);
        PowerUpService = new PowerUpService(powerUpScriptableObject);
        EnemyService = new EnemyService(enemyPrefab, enemyScriptableObject);
        VfxService = new VFXService(vfxScriptableObject);
    }

    private void Update()
    {
        PowerUpService?.Update();
        EnemyService?.Update();
    }

    private void CalculateAndSaveHighScore()
    {
        int score = PlayerService.GetHighScore();
        PlayerPrefs.SetInt("HighScore", score);
    }

    public void OnGameOver()
    {
        PowerUpService.SetPowerUpSpawning(false);
        PowerUpService.DestroyActivePowerUps();
        EnemyService.SetEnemySpawning(false);
        EnemyService.DestroyActiveEnemies();

        CalculateAndSaveHighScore();
        PlayerService.UpdateScoreValue(0);
    }
}
