using System;
using Character.StateMachines.Base;
using GameInput;

namespace StateMachines
{
    public class PlayerState : State<InputType>
    {
        public event Action<PlayerStateType> WantSwitchState;
        
        protected void SwitchState(PlayerStateType playerState)
        {
            WantSwitchState?.Invoke(playerState);
        }
    }
}