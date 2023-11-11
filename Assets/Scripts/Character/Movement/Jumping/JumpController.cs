using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;

namespace Movement
{
    public class JumpController
    {
        public event Action JumpStarted;
        public event Action FlyStarted;
        public event Action LandStarted;
        
        protected JumpConfig config;
        protected Transform player;

        protected float startY;
        
        private Sequence jumpSequence;
        
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
            JumpStarted?.Invoke();
            
            var jumpPos = CalculateJumpPos();
            var jumpTime = CalculateJumpTime();
            
            var jumpTween = player.DOLocalMoveY(jumpPos, jumpTime).SetEase(config.JumpCurve);
            jumpSequence.Insert(time, jumpTween);
            time += jumpTime;
        }

        private void AddFlyTween(ref float time)
        {
            var flyTime = CalculateFlyTime();
            
            jumpSequence.InsertCallback(time, () => FlyStarted?.Invoke());
            time += flyTime;
        }

        private void AddLandTween(ref float time)
        {
            var landTime = CalculateLandTime();
            
            jumpSequence.InsertCallback(time, () => LandStarted?.Invoke());
            var landTween = player.DOLocalMoveY(startY, landTime);
            jumpSequence.Insert(time, landTween);
        }
        
        #region Customizable behaviour

        protected virtual float CalculateJumpPos()
        {
            return startY + config.JumpHeight;
        }

        protected virtual float CalculateJumpTime()
        {
            return config.JumpTime;
        }

        protected virtual float CalculateFlyTime()
        {
            return config.FlyTime;
        }

        protected virtual float CalculateLandTime()
        {
            return config.LandTime;
        }

        #endregion
    }
}