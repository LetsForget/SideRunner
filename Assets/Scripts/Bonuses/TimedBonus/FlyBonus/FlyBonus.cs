using StateMachines;

namespace GameInput.Bonuses.FlyMultiplier
{
    public sealed class FlyBonus : TimedBonus<FlyBonusData>
    {
        private PlayerStateMachine stateMachine;
        
        public FlyBonus(FlyBonusData data, PlayerStateMachine stateMachine) : base(data)
        {
            this.stateMachine = stateMachine;
        }

        protected override void OnApply()
        {
            stateMachine.SwitchState(PlayerStateType.Flying);
        }

        protected override void OnBreak()
        {
            stateMachine.SwitchState(PlayerStateType.Running);
        }
    }
}