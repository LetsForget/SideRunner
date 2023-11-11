using Movement.Crawling;
using Movement.Jump;
using UnityEngine;
using UnityEngine.Serialization;

namespace Movement
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Transform player;
        
        [SerializeField] private JumpAnimation jumpAnimation;
        [SerializeField] private JumpConfig jumpConfig;
        
        private JumpController jumpController;

        [SerializeField] private CrawlAnimation crawlAnimation;
        [SerializeField] private CrawlConfig crawlConfig;
        
        private CrawlController crawlController;
        
        private void Start()
        {
            jumpController = new JumpController(jumpConfig, player);
            jumpAnimation.Initialize(jumpController);

            crawlController = new CrawlController(crawlConfig);
            crawlAnimation.Initialize(crawlController);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpController.Jump();
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                crawlController.Crawl();
            }
        }
    }
}