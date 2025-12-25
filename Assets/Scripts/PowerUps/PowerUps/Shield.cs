
using CosmicCuration.Player;

namespace CosmicCuration.PowerUps
{
    public class Shield : PowerUpController
    {
        public Shield(PowerUpData powerUpData) : base(powerUpData) { }

        public override void Activate()
        {
            base.Activate();
            GameService.Instance.PlayerService.GetPlayerController().SetShieldState(ShieldState.Activated);
            GameService.Instance.PlayerService.GetPlayerController().UpdateShieldUI(true);
        }

        public override void Deactivate()
        {
            base.Deactivate();
            GameService.Instance.PlayerService.GetPlayerController().SetShieldState(ShieldState.Deactivated);
            GameService.Instance.PlayerService.GetPlayerController().UpdateShieldUI(false);
        }
    } 
}