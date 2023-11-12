using Movement.Crawling;
using StateMachines;

namespace Movement.States
{
    public class CrawlState : PlayerState
    {
        private CrawlController controller;
        
        public CrawlState(CrawlController controller)
        {
            this.controller = controller;
        }

        public override void OnEnter()
        {
            base.OnEnter();
            
            controller.Crawl();
            controller.CrawlingFinished += OnCrawlingFinished;
        }

        private void OnCrawlingFinished()
        {
            SwitchState(PlayerStateType.Running);
        }
    }
}