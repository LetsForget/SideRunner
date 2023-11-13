using UnityEngine;

namespace Location
{
    public sealed class OneNodeLocationController : LocationController
    {
        private LocationNode firstNode;
        private LocationNode secondNode;

        public OneNodeLocationController(LocationConfig config, Transform locationHolder, Transform player) : base(config, locationHolder, player)
        {
            firstNode = SpawnNode(this.config.LocationNodes[0]);
            secondNode = SpawnNode(this.config.LocationNodes[0]);

            firstNode.name = "FirstNode";
            secondNode.name = "SecondNode";
            
            SetNodeInputPosTo(secondNode, player.position);
            SetNodeOutputPosTo(firstNode, secondNode.Input.position);
        }

        public override void Update()
        {
            base.Update();

            var delta = secondNode.Output.position - player.position;
            var distance = delta.magnitude;

            if (Vector3.Dot(delta, config.MoveDirection) > 0)
            {
                distance = -distance;
            }
            
            if (distance < config.UpdateNodeDistance || Input.GetKeyDown(KeyCode.A))
            {
                SetNodeInputPosTo(firstNode, secondNode.Output.position);

                var firNode = firstNode;
                var secNode = secondNode;
                
                firstNode = null;
                secondNode = null;

                secondNode = firNode;
                firstNode = secNode;

                firstNode.transform.parent = null;
                secondNode.transform.parent = null;

                locationHolder.localPosition = Vector3.zero;

                firstNode.transform.parent = locationHolder;
                secondNode.transform.parent = locationHolder;
            }
        }
    }
}