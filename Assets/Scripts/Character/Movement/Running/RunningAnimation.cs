using Movement.Animation;
using UnityEngine;

namespace Movement.Run
{
    public class RunningAnimation : AnimationController
    {
        private static readonly int RunMult = Animator.StringToHash("RunMult");

        public void SetMultiplier(float dataMultiplier)
        {
            animator.SetFloat(RunMult, dataMultiplier);
        }
    }
}