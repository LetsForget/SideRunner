using UnityEngine;

namespace GameInput.Bonuses
{
    public abstract class TimedBonusData : BonusData
    {
        /// <summary>
        /// Duration of bonus effect
        /// </summary>
        [field:SerializeField] public float BonusDuration { get; private set; } 
    }
}