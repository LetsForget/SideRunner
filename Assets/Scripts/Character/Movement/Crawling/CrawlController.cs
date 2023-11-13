using System;
using DG.Tweening;
using Movement.Crawling.CrawlParameters;
using UnityEngine;

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
        public float CrawlDuration => crawlingParameters.CalculateCrawlingDuration();

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

            // Animation transition to crawling started
            CrawlingStarted?.Invoke();

            var crawlDuration = CrawlDuration;
            
            // Waiting when crawling is over
            crawlSequence.InsertCallback(crawlDuration, () => CrawlingFinished?.Invoke());
        }
    }
}