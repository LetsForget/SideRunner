using System;

namespace Character.StateMachines.Base
{
    public abstract class State<Input> where Input : Enum
    {
        public virtual void OnEnter() { }
        
        public virtual void OnInput(Input input) { }
        
        public virtual void Update() { }
        
        public virtual void OnExit() { }
    }
}