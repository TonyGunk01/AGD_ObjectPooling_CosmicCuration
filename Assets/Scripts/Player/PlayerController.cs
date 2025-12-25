using System.Threading.Tasks;
using UnityEngine;
using CosmicCuration.Bullets;
using CosmicCuration.Audio;
using CosmicCuration.VFX;

namespace CosmicCuration.Player
{
    public class PlayerController
    {
        // Dependencies
        private PlayerView playerView;
        private PlayerScriptableObject playerScriptableObject;
        private BulletView bulletPrefab;
        private BulletScriptableObject bulletScriptableObject;

        // Variables
        private WeaponMode currentWeaponMode;
        private ShootingState currentShootingState;
        private ShieldState currentShieldState;
        private int currentHealth;
        private float currentRateOfFire;

        // Initialization
        public PlayerController(PlayerView playerViewPrefab, PlayerScriptableObject playerScriptableObject, BulletView bulletPrefab, BulletScriptableObject bulletScriptableObject)
        {
            playerView = Object.Instantiate(playerViewPrefab);
            playerView.SetController(this);
            this.playerScriptableObject = playerScriptableObject;
            this.bulletPrefab = bulletPrefab;
            this.bulletScriptableObject = bulletScriptableObject;

            InitializeVariables();
        }

        private void InitializeVariables()
        {
            currentWeaponMode = WeaponMode.SingleCanon;
            currentHealth = playerScriptableObject.maxHealth;
            currentRateOfFire = playerScriptableObject.defaultFireRate;
            currentShieldState = ShieldState.Deactivated;
            currentShootingState = ShootingState.NotFiring;
            GameService.Instance.UIService.UpdateHealthUI(currentHealth);
        }


        // Input Handling
        public void HandlePlayerInput()
        {
            HandlePlayerMovement();
            HandlePlayerRotation();
            HandleShooting();
        }

        private void HandlePlayerMovement()
        {
            if (Input.GetKey(KeyCode.W))
                playerView.transform.Translate(Vector2.up * Time.deltaTime * playerScriptableObject.movementSpeed);
            if (Input.GetKey(KeyCode.S))
                playerView.transform.Translate(Vector2.down * Time.deltaTime * playerScriptableObject.movementSpeed);
            if (Input.GetKey(KeyCode.A))
                playerView.transform.Translate(Vector2.left * Time.deltaTime * playerScriptableObject.movementSpeed);
            if (Input.GetKey(KeyCode.D))
                playerView.transform.Translate(Vector2.right * Time.deltaTime * playerScriptableObject.movementSpeed);
        }

        private void HandlePlayerRotation()
        {
            // Rotate the player to look in the direction of mouse position.
            var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(playerView.transform.position);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            playerView.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }

        private void HandleShooting()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                FireWeapon();
            if (Input.GetKeyUp(KeyCode.Space))
                currentShootingState = ShootingState.NotFiring;
        }

        // Firing Weapons
        private async void FireWeapon()
        {
            currentShootingState = ShootingState.Firing;
            while (currentShootingState == ShootingState.Firing)
            {
                switch (currentWeaponMode)
                {
                    case WeaponMode.SingleCanon:
                        FireBulletAtPosition(playerView.canonTransform);
                        break;
                    case WeaponMode.DoubleTurret:
                        FireBulletAtPosition(playerView.turretTransform1);
                        FireBulletAtPosition(playerView.turretTransform2);
                        break;
                }
                await Task.Delay(Mathf.RoundToInt(currentRateOfFire * 1000));
            }
        }

        private void FireBulletAtPosition(Transform fireLocation)
        {
            BulletController bulletToFire = new BulletController(bulletPrefab, bulletScriptableObject);
            bulletToFire.ConfigureBullet(fireLocation);
            GameService.Instance.SoundService.PlaySoundEffects(SoundType.PlayerBullet);
        } 

        // PowerUp Logic

        public void SetShieldState(ShieldState shieldStateToSet) => currentShieldState = shieldStateToSet;

        public void UpdateShieldUI(bool value)=> playerView.ToggleShieldUI(value);

        public void ToggleDoubleTurret(bool doubleTurretActive) => currentWeaponMode = doubleTurretActive ? WeaponMode.DoubleTurret : WeaponMode.SingleCanon;

        public void ToggleRapidFire(bool rapidFireActive) => currentRateOfFire = rapidFireActive ? playerScriptableObject.rapidFireRate : playerScriptableObject.defaultFireRate;

        public void TakeDamage(int damageToTake)
        {
            if (currentShieldState != ShieldState.Activated)
                currentHealth -= damageToTake;

            if (currentHealth <= 0)
                PlayerDeath();

            GameService.Instance.UIService.UpdateHealthUI(currentHealth);
        }

        private async void PlayerDeath()
        {
            Object.Destroy(playerView.gameObject);
            
            GameService.Instance.VfxService.PlayVFXAtPosition(VFXType.PlayerExplosion, playerView.transform.position);
            GameService.Instance.SoundService.PlaySoundEffects(SoundType.PlayerDeath);

            currentShootingState = ShootingState.NotFiring;
            GameService.Instance.EnemyService.SetEnemySpawning(false);
            GameService.Instance.PowerUpService.SetPowerUpSpawning(false);

            await Task.Delay(playerScriptableObject.deathDelay * 1000);
            GameService.Instance.UIService.EnableGameOverUI();
            GameService.Instance.OnGameOver();
        }

        public Vector3 GetPlayerPosition() => playerView != null ? playerView.transform.position : default;

        private enum WeaponMode
        {
            SingleCanon,
            DoubleTurret
        }

        private enum ShootingState
        {
            Firing,
            NotFiring
        }
    }

    public enum ShieldState
    {
        Activated,
        Deactivated
    }
}