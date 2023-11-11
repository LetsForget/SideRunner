namespace Movement.Jump.Parameters
{
    public class NormalJumpParameters : JumpParameters
    {
        public NormalJumpParameters(JumpConfig config, float startY) : base(config, startY) { }
        
        public override float CalculateJumpHeight()
        {
            return startY + config.JumpHeight;
        }

        public override float CalculateJumpTime()
        {
            return config.JumpTime;
        }

        public override float CalculateFlyTime()
        {
            return config.FlyTime;
        }

        public override float CalculateLandTime()
        {
            return config.LandTime;
        }
    }
}