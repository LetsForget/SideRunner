using System;
using GameInput.Bonuses;
using UnityEngine;

namespace GameInput.Character
{
    public class CollisionController : MonoBehaviour
    {
        public event Action<BonusData> BonusEarned; 

        private void OnTriggerEnter(Collider other)
        {
            var bonusHolder = other.GetComponent<BonusHolder>();
            if (bonusHolder)
            {
                BonusEarned?.Invoke(bonusHolder.Data);
            }       
        }
    }
}