using Movement.Animation;
using UnityEngine;

namespace Movement.Jump
{
    /// <summary>
    /// Jump animation handler
    /// </summary>
    public class JumpAnimation : AnimationController
    {
        private const string JumpAnimationName = "Jump_";
        private const string LandAnimationName = "Land_";
        
        private static readonly int JumpTrigger = Animator.StringToHash("Jump");
        private static readonly int JumpMult = Animator.StringToHash("JumpMult");
        
        private static readonly int LandTrigger = Animator.StringToHash("Land");
        private static readonly int LandMult = Animator.StringToHash("LandMult");

        private float jumpTime;
        private float landTime;
        
        public void OnJumped(float jumpTime, float landTime)
        {
            // Starting animation in animator
            animator.SetTrigger(JumpTrigger);

            this.jumpTime = jumpTime;
            this.landTime = landTime;
        }
        
        public void OnLandingStarted()
        {
            //After player flying at height over, calling trigger to start landing anim
            animator.SetTrigger(LandTrigger);
        }
        
        #region Animation events

        private void JumpStarted()
        {
            // Finding clip and set animator speed according to clip's length and jump time
            var clip = FindClip(JumpAnimationName);

            if (clip == null)
            {
                return;
            }
            
            SetSpeed(clip, jumpTime,JumpMult);
        }
        
        private void LandStarted()
        {            
            // Finding clip and set animator speed according to clip's length and land time
            var clip = FindClip(LandAnimationName);

            if (clip == null)
            {
                return;
            }
            
            SetSpeed(clip, landTime, LandMult);
        }
        #endregion
    }
}