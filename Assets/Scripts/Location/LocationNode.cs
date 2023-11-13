using UnityEngine;

namespace Location
{
    public class LocationNode : MonoBehaviour
    {
        /// <summary>
        /// Start point, socket
        /// </summary>
        [field: SerializeField] public Transform Input { get; private set; }
        
        /// <summary>
        /// End point, plug
        /// </summary>
        [field: SerializeField] public Transform Output { get; private set; }

        /// <summary>
        /// Possible placeholders for bonuses
        /// </summary>
        [field: SerializeField] public Transform[] BonusHolders { get; private set; }
        
        /// <summary>
        /// Distance from input node to output node
        /// </summary>
        public float Distance => Vector3.Distance(Input.position, Output.position);
    }
}