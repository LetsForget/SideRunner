namespace Movement.Crawling.CrawlParameters
{
    public class NormalCrawlingParameters : CrawlingParameters
    {
        public NormalCrawlingParameters(CrawlConfig config) : base(config) { }
        
        public override float CalculateCrawlingDuration()
        {
            return config.CrawlDuration;
        }
    }
}