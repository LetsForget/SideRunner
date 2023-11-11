using Movement.Animation;
using UnityEngine;

namespace Movement.Jump
{
    /// <summary>
    /// Jump animation handler
    /// </summary>
    public class JumpAnimation : BaseAnimationController
    {
        private const string JumpAnimationName = "Jump_";
        private const string LandAnimationName = "Land_";
        
        private static readonly int LandTrigger = Animator.StringToHash("Land");
        private static readonly int JumpTrigger = Animator.StringToHash("Jump");
        
        private JumpController controller;
        
        public void Initialize(JumpController controller)
        {
            base.Initialize();
            
            this.controller = controller;
            
            this.controller.Jumped += OnJumped;
            this.controller.LandingStarted += OnLandingStarted;
            this.controller.Landed += OnLanded;
        }

        private void OnJumped()
        {
            // Starting animation in animator
            animator.SetTrigger(JumpTrigger);
        }

        public void JumpStarted()
        {
            // Finding clip and set animator speed according to clip's length and jump time
            var clip = FindClip(JumpAnimationName);

            if (clip == null)
            {
                return;
            }
            
            SetSpeed(clip, controller.JumpTime);
        }
        
        private void OnLandingStarted()
        {
            //After player flying at height over, calling trigger to start landing anim
            animator.SetTrigger(LandTrigger);
        }
        
        public void LandStarted()
        {            
            // Finding clip and set animator speed according to clip's length and land time
            var clip = FindClip(LandAnimationName);

            if (clip == null)
            {
                return;
            }
            
            SetSpeed(clip, controller.LandTime);
        }

        private void OnLanded()
        {
            ResetAnimatorSpeed();
        }
    }
}