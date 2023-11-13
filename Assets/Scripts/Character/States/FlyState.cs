using StateMachines;
using UnityEngine;

namespace Movement.States
{
    public class FlyState : PlayerState
    {
        private Transform player;
        
        public FlyState(Transform player)
        {
            this.player = player;
        }
        
        public override void OnEnter()
        {
            base.OnEnter();
            
            player.transform.position += Vector3.up;
        }

        public override void OnExit()
        {
            base.OnExit();

            player.transform.position -= Vector3.up;
        }
    }
}