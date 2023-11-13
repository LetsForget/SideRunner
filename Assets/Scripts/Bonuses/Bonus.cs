namespace GameInput.Bonuses
{
    public abstract class Bonus<TData> where TData : BonusData
    {
        protected TData data;
        
        public Bonus(TData data)
        {
            this.data = data;
        }

        public abstract void Apply();

        public abstract void Break();
    }
}