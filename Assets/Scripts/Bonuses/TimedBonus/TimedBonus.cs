using DG.Tweening;

namespace GameInput.Bonuses
{
    public abstract class TimedBonus<TData> : Bonus<TData> where TData : TimedBonusData
    {
        protected TimedBonus(TData data) : base(data) { }

        private Sequence bonusSequence;
        
        public override void Apply()
        {
            bonusSequence.InsertCallback(data.BonusDuration, Break);
            
            OnApply();
        }

        protected abstract void OnApply();
        
        public override void Break()
        {
            bonusSequence?.Kill(false);
            bonusSequence = null;
            
            OnBreak();
        }

        protected abstract void OnBreak();
    }
}