﻿using UnityEngine;

namespace Movement
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private JumpConfig jumpConfig;
        [SerializeField] private Transform player;
        
        private JumpController jumpController;

        private void Start()
        {
            jumpController = new JumpController(jumpConfig, player);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jumpController.Jump();
            }
        }
    }
}