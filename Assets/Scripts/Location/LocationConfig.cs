using UnityEngine;

namespace Location
{
    [CreateAssetMenu(menuName = "Assets/Configs/Location config", fileName = "Location config")]
    public class LocationConfig : ScriptableObject
    {
        /// <summary>
        /// Distance from output position of current node to player at which next node will appear
        /// </summary>
        [field: SerializeField] public float UpdateNodeDistance { get; private set; }
        
        /// <summary>
        /// Parts of the location
        /// </summary>
        [field: SerializeField] public LocationNode[] LocationNodes { get; private set; }
        
        /// <summary>
        /// Direction of which the location should be moving
        /// </summary>
        [field: SerializeField] public Vector3 MoveDirection { get; private set; }
    }
}