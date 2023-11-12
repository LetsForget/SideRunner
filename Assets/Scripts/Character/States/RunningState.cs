using GameInput;
using StateMachines;

namespace Movement.States
{
    public class RunningState : PlayerState
    {
        public override void OnInput(InputType input)
        {
            base.OnInput(input);

            switch (input)
            {
                case InputType.Jump:
                    SwitchState(PlayerStateType.Jumping);
                    break;
                case InputType.Crawl:
                    SwitchState(PlayerStateType.Crawling);
                    break;
            }
        }
    }
}