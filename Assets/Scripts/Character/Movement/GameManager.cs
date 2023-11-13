using GameInput;
using Location;
using Movement.Animation;
using Movement.Crawling;
using Movement.Jump;
using Movement.Run;
using StateMachines;
using UnityEngine;

namespace Movement
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private Transform player;
        [SerializeField] private RunningAnimation runningAnimation;
        
        [Header("Jumping")]
        [SerializeField] private JumpConfig jumpConfig;
        [SerializeField]private JumpAnimation jumpAnimation;
        private JumpController jumpController;
        
        [Header("Crawling")]
        [SerializeField] private CrawlConfig crawlConfig;
        [SerializeField] private CrawlAnimation crawlAnimation;
        private CrawlController crawlController;

        [Header("Location")] 
        [SerializeField] private LocationConfig locationConfig;
        [SerializeField] private Transform locationHolder;

        [Header("Collision")] 
        [SerializeField] private BoxCollider collision;
        
        private LocationController locationController;
        private PlayerStateMachine playerStateMachine;
        
        private void Start()
        {
            // Animation initialization
            runningAnimation.Initialize(animator);
            jumpAnimation.Initialize(animator);
            crawlAnimation.Initialize(animator);
            
            // Jumping initialization
            jumpController = new JumpController(jumpConfig, player);
            jumpController.Jumped += jumpAnimation.OnJumped;
            jumpController.LandingStarted += jumpAnimation.OnLandingStarted;

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