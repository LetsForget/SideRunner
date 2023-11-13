using GameInput;
using Location;
using Movement.Crawling;
using Movement.Jump;
using StateMachines;
using UnityEngine;

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

        [Header("Jumping")] 
        [SerializeField] private BoxCollider collision;

        private BaseLocationController locationController;
        private PlayerStateMachine playerStateMachine;
        
        private void Start()
        {
            // Jumping initialization
            jumpController = new JumpController(jumpConfig, player);
            jumpController.Jumped += jumpAnimation.OnJumped;
            jumpController.LandingStarted += jumpAnimation.OnLandingStarted;
            jumpController.Landed += jumpAnimation.OnLanded;
            
            // Crawling initialization
            crawlController = new CrawlController(crawlConfig);
            crawlController.CrawlingStarted += crawlAnimation.OnCrawlingStarted;
            crawlController.CrawlingFinished += crawlAnimation.OnCrawlingFinished;

            // Location initialization
            locationController = new OneNodeLocationController(locationConfig, locationHolder, player);
            
            // Creating player state machine
            playerStateMachine = new PlayerStateMachine(jumpController, crawlController);
            
            // Collision initialization
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerStateMachine.OnInput(InputType.Jump);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerStateMachine.OnInput(InputType.Crawl);
            }

            playerStateMachine.Update();
            locationController.Update();
        }
    }
}