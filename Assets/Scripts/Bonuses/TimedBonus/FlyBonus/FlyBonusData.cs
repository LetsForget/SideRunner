using UnityEngine;

namespace GameInput.Bonuses.FlyMultiplier
{
    [CreateAssetMenu(menuName = "Assets/Configs/Bonuses/Fly bonus", fileName = "Fly bonus")]
    public class FlyBonusData : TimedBonusData
    {
        public override BonusesRelations Relations => BonusesRelations.BreaksAll;
        public override BonusType Type => BonusType.FlyBonus;
    }
}