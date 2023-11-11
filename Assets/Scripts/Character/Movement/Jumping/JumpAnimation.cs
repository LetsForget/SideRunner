using UnityEngine;

namespace Movement.Jump
{
    /// <summary>
    /// Jump animation handler
    /// </summary>
    public class JumpAnimation : MonoBehaviour
    {
        private const string JumpAnimationName = "Jump_";
        private const string LandAnimationName = "Land_";
        
        private static readonly int LandTrigger = Animator.StringToHash("Land");
        private static readonly int JumpTrigger = Animator.StringToHash("Jump");
        
        private Animator animator;
        private JumpController controller;

        private float defaultAnimatorSpeed;
        
        public void Initialize(JumpController controller)
        {
            animator = GetComponent<Animator>();
            defaultAnimatorSpeed = animator.speed;
            
            this.controller = controller;
            
            this.controller.Jumped += OnJumped;
            this.controller.LandingStarted += OnLandingStarted;
            this.controller.Landed += OnLanded;
        }

        #region Main animation cycle

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
            animator.speed = defaultAnimatorSpeed;
        }

        #endregion

        #region Misc

        private AnimationClip FindClip(string name)
        {
            var clipInfos = animator.GetCurrentAnimatorClipInfo(0);
            var clip = FindClip(clipInfos, name);

            if (clip == null)
            {
                clipInfos = animator.GetNextAnimatorClipInfo(0);
                clip = FindClip(clipInfos, name);
            }

            return clip;
        }
        
        private AnimationClip FindClip(AnimatorClipInfo[] clipInfos, string name)
        {
            foreach (var info in clipInfos)
            {
                if (info.clip.name.Contains(name))
                {
                    return info.clip;
                }
            }

            return null;
        }
        
        private void SetSpeed(AnimationClip clip, float length)
        {
            var neededSpeed = clip.length / length;
            animator.speed = neededSpeed;
        }

        #endregion
    }
}