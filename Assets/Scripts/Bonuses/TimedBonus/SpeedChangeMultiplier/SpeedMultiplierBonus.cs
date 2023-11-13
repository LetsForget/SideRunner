using Location;
using Movement.Run;

namespace GameInput.Bonuses
{
    public sealed class SpeedMultiplierBonus : TimedBonus<SpeedMultiplierBonusData>
    {
        private LocationController locationController;
        private RunningAnimation runningAnimation;

        public SpeedMultiplierBonus(SpeedMultiplierBonusData data, LocationController locationController, RunningAnimation runningAnimation) : base(data)
        {
            this.locationController = locationController;
            this.runningAnimation = runningAnimation;
        }

        protected override void OnApply()
        {
            runningAnimation.SetMultiplier(data.Multiplier);
            locationController.SetSpeedMultiplier(data.Multiplier);
        }

        protected override void OnBreak()
        {
            runningAnimation.SetMultiplier(1);
            locationController.SetSpeedMultiplier(1);
        }
    }
}