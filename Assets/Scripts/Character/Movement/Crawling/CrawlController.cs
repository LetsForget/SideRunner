using System;
using DG.Tweening;
using Movement.Crawling.CrawlParameters;

namespace Movement.Crawling
{
    public class CrawlController
    {
        /// <summary>
        /// Invokes when crawl sequence is about to start
        /// </summary>
        public event Action CrawlingStarted;

        /// <summary>
        /// Invokes when player started to stand up
        /// </summary>
        public event Action CrawlingFinished;
        
        private CrawlConfig config;
        private CrawlingParameters crawlingParameters;
        
        private Sequence crawlSequence;

        /// <summary>
        /// Duration the player will be crawling
        /// </summary>
        public float CrawlTime => crawlingParameters.CalculateCrawlingTime();

        public CrawlController(CrawlConfig config)
        {
            this.config = config;
            crawlingParameters = new NormalCrawlingParameters(config);
        }
        
        /// <summary>
        /// Creates a sequence that makes player crawl. If previous sequence is active, player won't crawl 
        /// </summary>
        public void Crawl()
        {
            // return if player is already jumping
            if (crawlSequence != null && crawlSequence.active)
            {
                return;
            }
            
            // creating sequence for jump
            crawlSequence = DOTween.Sequence();

            var time = 0f;
            
            // Transition to crawling started
            CrawlingStarted?.Invoke();
            
            // Waiting when crawling is over
            time += CrawlTime;
            crawlSequence.InsertCallback(time, () => CrawlingFinished?.Invoke());
        }
    }
}