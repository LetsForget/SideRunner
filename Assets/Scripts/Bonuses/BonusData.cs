using UnityEngine;

namespace GameInput.Bonuses
{
    public abstract class BonusData : ScriptableObject
    {
        /// <summary>
        /// What game should with other bonuses when this'll be aplied
        /// </summary>
        public abstract BonusesRelations Relations { get; }
        
        /// <summary>
        /// Type of that bonus
        /// </summary>
        public abstract BonusType Type { get; }
    }

    public enum BonusesRelations
    {
        BreaksAll,
        BreaksSameType
    }

    public enum BonusType
    {
        SpeedMultiplier,
        FlyBonus
    }
}