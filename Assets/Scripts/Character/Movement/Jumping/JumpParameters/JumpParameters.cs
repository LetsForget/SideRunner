namespace Movement.Jump.Parameters
{
    public abstract class JumpParameters
    {
        protected float startY;
        protected JumpConfig config;
        
        public JumpParameters(JumpConfig config, float startY)
        {
            this.startY = startY;
            this.config = config;
        }
        
        public abstract float CalculateJumpHeight();

        public abstract float CalculateJumpTime();

        public abstract float CalculateFlyTime();

        public abstract float CalculateLandTime();
    }
}