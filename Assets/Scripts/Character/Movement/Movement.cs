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
        
        private BaseLocationController locationController;
        private PlayerStateMachine playerStateMachine;
        
        private void Start()
        {
            jumpController = new JumpController(jumpConfig, player);
            jumpAnimation.Initialize(jumpController);

            crawlController = new CrawlController(crawlConfig);
            crawlAnimation.Initialize(crawlController);

            locationController = new OneNodeLocationController(locationConfig, locationHolder, player);
            playerStateMachine = new PlayerStateMachine(jumpController, crawlController);
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