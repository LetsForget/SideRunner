using UnityEngine;

namespace Location
{
    public abstract class BaseLocationController
    {
        protected LocationConfig config;
        protected Transform locationHolder;
        protected Transform player;

        protected LocationMover locationMover;
        
        public BaseLocationController(LocationConfig config, Transform locationHolder, Transform player)
        {
            this.config = config;
            this.locationHolder = locationHolder;
            this.player = player;

            locationMover = new LocationMover(this.locationHolder, config.MoveDirection);
        }
        
        protected void SetNodeInputPosTo(LocationNode node, Vector3 pos)
        {
            var nodeInputPos = node.Input.position;

            var delta = pos - nodeInputPos;
            delta.y = 0;
            
            node.transform.position += delta;
        }
        
        protected void SetNodeOutputPosTo(LocationNode node, Vector3 pos)
        {
            var nodeOutputPos = node.Output.position;

            var delta = pos - nodeOutputPos;
            delta.y = 0;
            
            node.transform.position += delta;
        }
        
        protected LocationNode SpawnNode(LocationNode prefab)
        {
            return GameObject.Instantiate(prefab, locationHolder);
        }

        public virtual void Update()
        {
            locationMover.Update();
        }
    }
}