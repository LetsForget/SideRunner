using System;
using DG.Tweening;
using Movement.Jump.Parameters;
using UnityEngine;

namespace Movement.Jump
{
    public class JumpController
    {
        /// <summary>
        /// Invokes when jump sequence is about to start
        /// </summary>
        public event Action<float, float> Jumped;
        
        /// <summary>
        /// Invokes when landing is about to start
        /// </summary>
        public event Action LandingStarted;
        
        /// <summary>
        /// Invokes when jump sequence is finished
        /// </summary>
        public event Action Landed;
        
        protected JumpConfig config;
        protected Transform player;
        protected JumpParameters parameters;
        
        protected float startY;
        
        private Sequence jumpSequence;

        /// <summary>
        ///  The Y value to which it will jump
        /// </summary>
        public float JumpHeight => parameters.CalculateJumpHeight();
        /// <summary>
        /// Duration of the lifting phase
        /// </summary>
        public float JumpTime => parameters.CalculateJumpTime();
        /// <summary>
        /// The time for which the transform will hang in the air
        /// </summary>
        public float FlyTime => parameters.CalculateFlyTime();
        /// <summary>
        /// Duration of the falling phase
        /// </summary>
        public float LandTime => parameters.CalculateLandTime();
        
        public JumpController(JumpConfig config, Transform player)
        {
            this.config = config;
            this.player = player;

            startY = this.player.localPosition.y;
            parameters = new NormalJumpParameters(this.config, startY);
        }

        /// <summary>
        /// Creates a sequence that makes player jump. If previous sequence is active, player won't jump 
        /// </summary>
        public void Jump()
        {
            // return if player is already jumping
            if (jumpSequence != null && jumpSequence.active)
            {
                return;
            }
            
            var jumpTime = JumpTime;
            var flyTime = FlyTime;
            var landTime = LandTime;
            Jumped?.Invoke(jumpTime, landTime);
            
            // creating sequence for jump
            jumpSequence = DOTween.Sequence();

            var time = 0f;
            
            // Creating a tween to raise player up
            var jumpTween = player.DOLocalMoveY(JumpHeight, jumpTime).SetEase(config.JumpCurve);
            jumpSequence.Insert(time, jumpTween);
            time += jumpTime;
            
            // Adding time to counter to make player hang in the air for a fly time
            time += flyTime;

            // Creating a tween to lower player back to previous height 
            var landTween = player.DOLocalMoveY(startY, landTime).SetEase(config.LandCurve);
            jumpSequence.Insert(time, landTween);
            jumpSequence.InsertCallback(time, () => LandingStarted?.Invoke());
            
            time += landTime;
            jumpSequence.InsertCallback(time, () => Landed?.Invoke());
        }
    }
}