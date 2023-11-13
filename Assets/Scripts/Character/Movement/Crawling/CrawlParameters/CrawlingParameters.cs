namespace Movement.Crawling.CrawlParameters
{
    public abstract class CrawlingParameters
    {
        protected CrawlConfig config;
        
        public CrawlingParameters(CrawlConfig config)
        {
            this.config = config;
        }
        
        public abstract float CalculateCrawlingDuration();
    }
}