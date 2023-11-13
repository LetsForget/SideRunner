using System;
using UnityEngine;

namespace Movement.Animation
{
    public class AnimationController : MonoBehaviour
    {
        protected Animator animator;

        public void Initialize(Animator animator)
        {
            this.animator = animator;
        }

        /// <summary>
        /// Find clip in current animator clip infos animator by given name
        /// </summary>
        protected AnimationClip FindClip(string name)
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
        
        /// <summary>
        /// Find clip in given clip infos by given name 
        /// </summary>
        protected AnimationClip FindClip(AnimatorClipInfo[] clipInfos, string name)
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
        
        /// <summary>
        /// Sets animator speed in the way that given clip plays for given length
        /// </summary>
        /// <param name="clip">Clip to play particular time</param>
        /// <param name="Duration">Time in sec</param>
        protected void SetSpeed(AnimationClip clip, float Duration, int multiplierHash)
        {
            var multiplier = clip.length / Duration;
            animator.SetFloat(multiplierHash, multiplier);
        }
    }
}