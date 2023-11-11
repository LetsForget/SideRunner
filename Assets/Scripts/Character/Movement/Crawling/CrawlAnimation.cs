using Movement.Animation;
using UnityEngine;

namespace Movement.Crawling
{
    public class CrawlAnimation : BaseAnimationController
    {
        private static readonly int CrawlTrigger = Animator.StringToHash("Crawl");
        private static readonly int StandTrigger = Animator.StringToHash("Stand");
        
        private CrawlController controller;
        
        public void Initialize(CrawlController controller)
        {
            base.Initialize();

            this.controller = controller;
            
            this.controller.CrawlingStarted += OnCrawlingStarted;
            this.controller.CrawlingFinished += OnCrawlingFinished;
        }
        
        private void OnCrawlingStarted()
        {
            // Starting animation in animator
            animator.SetTrigger(CrawlTrigger);
        }
        
        private void OnCrawlingFinished()
        {
            animator.SetTrigger(StandTrigger);
        }
    }
}