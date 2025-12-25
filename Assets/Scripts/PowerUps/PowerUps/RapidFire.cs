namespace CosmicCuration.PowerUps
{
    public class RapidFire : PowerUpController
    {
        public RapidFire(PowerUpData powerUpData) : base(powerUpData) { }

        public override void Activate()
        {
            base.Activate();
            GameService.Instance.PlayerService.GetPlayerController().ToggleRapidFire(true);
            GameService.Instance.UIService.TogglePowerUpUI(true, PowerUpType.RapidFire);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            GameService.Instance.PlayerService.GetPlayerController().ToggleRapidFire(false);
            GameService.Instance.UIService.TogglePowerUpUI(false, PowerUpType.RapidFire);
        }
    }
}