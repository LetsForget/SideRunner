using System;
using System.Collections.Generic;
using GameInput;
using GameInput.Bonuses;
using GameInput.Bonuses.FlyMultiplier;
using GameInput.Character;
using Location;
using Movement.Animation;
using Movement.Crawling;
using Movement.Jump;
using Movement.Run;
using StateMachines;
using UnityEngine;

namespace Game
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
        [SerializeField] private CollisionController collisionController;
        
        private LocationController locationController;
        private PlayerStateMachine playerStateMachine;

        private List<Bonus> currentBonuses;

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
            collisionController.BonusEarned += OnBonusEarned;
            currentBonuses = new List<Bonus>();
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
        
        private void OnBonusEarned(BonusData bonusData)
        {
            var newBonusType = bonusData.Type;
            var relationsType = bonusData.Relations;

            var bonusesCount = currentBonuses.Count - 1; 
            for (var i = bonusesCount; i >= 0; i--)
            {
                var bonus = currentBonuses[i];
                
                if (bonus.Completed)
                {
                    currentBonuses.Remove(bonus);
                    continue;
                }
                
                switch (relationsType)
                {
                    case BonusesRelations.BreaksAll:
                        bonus.Break();
                        currentBonuses.Remove(bonus);
                        break;
                    case BonusesRelations.BreaksSameType:
                        if (bonus.Type == newBonusType)
                        {
                            bonus.Break();
                            currentBonuses.Remove(bonus);
                        }
                        break;
                }
            }

            Bonus newBonus = null;
            
            switch (newBonusType)
            {
                case BonusType.SpeedMultiplier:
                    var speedData = bonusData as SpeedMultiplierBonusData;
                    newBonus = new SpeedMultiplierBonus(speedData, locationController, runningAnimation);
                    break;
                case BonusType.FlyBonus:
                    var flyData = bonusData as FlyBonusData;
                    newBonus = new FlyBonus(flyData, playerStateMachine);
                    break;
            }
            
            newBonus.Apply();
            currentBonuses.Add(newBonus);
        }
    }
}