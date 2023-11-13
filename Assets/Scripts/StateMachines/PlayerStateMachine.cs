using Character.StateMachines.Base;
using GameInput;
using Movement.Crawling;
using Movement.Jump;
using Movement.States;
using UnityEngine;

namespace StateMachines
{
    public sealed class PlayerStateMachine : StateMachine<InputType>
    {
        private JumpController jumpController;
        private CrawlController crawlController;
        
        private PlayerState CurrentPlayerState => CurrentState as PlayerState;
        
        public PlayerStateMachine(JumpController jumpController, CrawlController crawlController)
        {
            this.jumpController = jumpController;
            this.crawlController = crawlController;
            
            OnWantSwitchState(PlayerStateType.Running);
        }
        
        protected override void EnterNewState()
        {
            CurrentPlayerState.WantSwitchState += OnWantSwitchState;
           
            base.EnterNewState();
        }

        protected override void ExitFromState()
        {
            CurrentPlayerState.WantSwitchState -= OnWantSwitchState;
            
            base.ExitFromState();
        }

        private void OnWantSwitchState(PlayerStateType newType)
        {
            PlayerState state = null;
            
            switch (newType)
            {
                case PlayerStateType.Running:
                    state = new RunningState();
                    break;
                case PlayerStateType.Jumping:
                    state = new JumpState(jumpController);
                    break;
                case PlayerStateType.Crawling:
                    state = new CrawlState(crawlController);
                    break;
            }

            if (state == null)
            {
                Debug.LogError("Unknown state " + newType);
                return;
            }
            
            GoToState(state);
        }
    }
}