using UnityEngine;

namespace GameInput.Bonuses
{
    [CreateAssetMenu(menuName = "Assets/Configs/Bonuses/Speed multiplier bonus", fileName = "Speed bonus")]
    public class SpeedMultiplierBonusData : TimedBonusData
    {
        public override BonusesRelations Relations => BonusesRelations.BreaksSameType;
        public override BonusType Type => BonusType.SpeedMultiplier;
        
        /// <summary>
        /// Change of running speed
        /// </summary>
        [field:SerializeField] public float Multiplier { get; private set; }
    }
}