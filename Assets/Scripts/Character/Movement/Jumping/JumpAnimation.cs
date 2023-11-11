using UnityEngine;

namespace Movement.Jump
{
    public class JumpAnimation : MonoBehaviour
    {
        private const string jumpAnimationName = "Jump_";
        private const string landAnimationName = "Land_";
        
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
            animator.SetTrigger(JumpTrigger);
        }

        public void JumpStarted()
        {
            var clipInfos = animator.GetCurrentAnimatorClipInfo(0);
            var clip = FindClip(clipInfos, jumpAnimationName);

            if (clip == null)
            {
                clipInfos = animator.GetNextAnimatorClipInfo(0);
                clip = FindClip(clipInfos, jumpAnimationName);
            }

            if (clip == null)
            {
                return;
            }
            
            SetSpeed(clip, controller.JumpTime);
        }
        
        private void OnLandingStarted()
        {
            animator.SetTrigger(LandTrigger);
        }
        
        public void LandStarted()
        {
            var clipInfos = animator.GetCurrentAnimatorClipInfo(0);
            var clip = FindClip(clipInfos, landAnimationName);

            if (clip == null)
            {
                clipInfos = animator.GetNextAnimatorClipInfo(0);
                clip = FindClip(clipInfos, landAnimationName);
            }

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