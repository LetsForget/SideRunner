using UnityEngine;

namespace GameInput.Bonuses
{
    public abstract class Bonus
    {
        public bool Completed { get; private set; }
        
        public abstract void Apply();

        public virtual void Break()
        {
            Completed = true;
        }

        public abstract BonusType Type { get; }
    }
    
    public abstract class Bonus<TData> : Bonus where TData : BonusData
    {
        [SerializeField] protected TData data;

        public override BonusType Type => data.Type;

        public Bonus(TData data)
        {
            this.data = data;
        }
    }
}