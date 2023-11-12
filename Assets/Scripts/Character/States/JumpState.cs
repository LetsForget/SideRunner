using Movement.Jump;
using StateMachines;

namespace Movement.States
{
    public class JumpState : PlayerState
    {
        private JumpController controller;
        
        public JumpState(JumpController controller)
        {
            this.controller = controller;
        }
        
        public override void OnEnter()
        {
            base.OnEnter();

            controller.Jump();
            controller.Landed += OnLanded;
        }

        private void OnLanded()
        {
            SwitchState(PlayerStateType.Running);
        }
    }
}