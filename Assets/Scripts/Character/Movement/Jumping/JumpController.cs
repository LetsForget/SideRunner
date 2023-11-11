using System;
using DG.Tweening;
using Movement.Jump.Parameters;
using UnityEngine;

namespace Movement.Jump
{
    public class JumpController
    {
        public event Action Jumped;
        public event Action LandingStarted;
        public event Action Landed;
        
        protected JumpConfig config;
        protected Transform player;
        protected JumpParameters parameters;
        
        protected float startY;
        
        private Sequence jumpSequence;

        public float JumpHeight => parameters.CalculateJumpHeight();
        public float JumpTime => parameters.CalculateJumpTime();
        public float FlyTime => parameters.CalculateFlyTime();
        public float LandTime => parameters.CalculateLandTime();
        
        public JumpController(JumpConfig config, Transform player)
        {
            this.config = config;
            this.player = player;

            startY = this.player.localPosition.y;
        }

        /// <summary>
        /// Creates a sequence that makes player jump. If previous sequence is active, player won't jump 
        /// </summary>
        public void Jump()
        {
            if (jumpSequence != null && jumpSequence.active)
            {
                return;
            }
            
            jumpSequence?.Kill();
            jumpSequence = DOTween.Sequence();

            var time = 0f;
            
            AddJumpTween(ref time);
            AddFlyTween(ref time);
            AddLandTween(ref time);
        }
        
        private void AddJumpTween(ref float time)
        {
            Jumped?.Invoke();

            var jumpTime = JumpTime;
            
            var jumpTween = player.DOLocalMoveY(JumpHeight, jumpTime).SetEase(config.JumpCurve);
            jumpSequence.Insert(time, jumpTween);
            time += jumpTime;
        }

        private void AddFlyTween(ref float time)
        {
            time += FlyTime;
        }

        private void AddLandTween(ref float time)
        {
            var landTime = LandTime;
            
            var landTween = player.DOLocalMoveY(startY, landTime).SetEase(config.LandCurve);
            jumpSequence.Insert(time, landTween);
            jumpSequence.InsertCallback(time, () => LandingStarted?.Invoke());
            
            time += landTime;
            jumpSequence.InsertCallback(time, () => Landed?.Invoke());
        }
    }
}