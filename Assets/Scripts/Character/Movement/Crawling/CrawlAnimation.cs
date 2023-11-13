using Movement.Animation;
using UnityEngine;

namespace Movement.Crawling
{
    public class CrawlAnimation : BaseAnimationController
    {
        private static readonly int CrawlTrigger = Animator.StringToHash("Crawl");
        private static readonly int StandTrigger = Animator.StringToHash("Stand");
        
        public void OnCrawlingStarted()
        {
            // Starting crawling animation in animator
            animator.SetTrigger(CrawlTrigger);
        }
        
        public void OnCrawlingFinished()
        {
            // Starting runnin animation in animator
            animator.SetTrigger(StandTrigger);
        }
    }
}