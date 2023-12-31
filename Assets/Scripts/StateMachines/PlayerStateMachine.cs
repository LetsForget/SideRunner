﻿using Character.StateMachines.Base;
using GameInput;
using Movement.Crawling;
using Movement.Jump;
using Movement.States;
using UnityEngine;

namespace StateMachines
{
    public sealed class PlayerStateMachine : StateMachine<InputType>
    {
        private Transform player;
        private JumpController jumpController;
        private CrawlController crawlController;
        
        private PlayerState CurrentPlayerState => CurrentState as PlayerState;
        
        public PlayerStateMachine(JumpController jumpController, CrawlController crawlController, Transform player)
        {
            this.jumpController = jumpController;
            this.crawlController = crawlController;
            this.player = player;
            
            SwitchState(PlayerStateType.Running);
        }
        
        protected override void EnterNewState()
        {
            CurrentPlayerState.WantSwitchState += SwitchState;
           
            base.EnterNewState();
        }

        protected override void ExitFromState()
        {
            CurrentPlayerState.WantSwitchState -= SwitchState;
            
            base.ExitFromState();
        }

        public void SwitchState(PlayerStateType newType)
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
                case PlayerStateType.Flying:
                    state = new FlyState(player);
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