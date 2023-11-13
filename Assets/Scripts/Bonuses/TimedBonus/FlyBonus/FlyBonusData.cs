namespace GameInput.Bonuses.FlyMultiplier
{
    public class FlyBonusData : TimedBonusData
    {
        public override BonusesRelations Relations => BonusesRelations.BreaksAll;
        public override BonusType Type => BonusType.FlyBonus;
    }
}