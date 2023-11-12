using Location;
using Movement.Crawling;
using Movement.Jump;
using UnityEngine;
using UnityEngine.Serialization;

namespace Movement
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private Transform player;
        
        [Header("Jumping")]
        [SerializeField] private JumpAnimation jumpAnimation;
        [SerializeField] private JumpConfig jumpConfig;
        
        private JumpController jumpController;

        [Header("Crawling")]
        [SerializeField] private CrawlAnimation crawlAnimation;
        [SerializeField] private CrawlConfig crawlConfig;
        
        private CrawlController crawlController;

        [Header("Location")] 
        [SerializeField] private LocationConfig locationConfig;
        [SerializeField] private Transform locationHolder;
        
        private BaseLocationController locationController;
        
        private void Start()
        {
            jumpController = new JumpController(jumpConfig, player);
            jumpAnimation.Initialize(jumpController);

            crawlController = new CrawlController(crawlConfig);
            crawlAnimation.Initialize(crawlController);

            locationController = new OneNodeLocationController(locationConfig, locationHolder, player);
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

            locationController.Update();
        }
    }
}