using UnityEngine;

namespace Location
{
    public class LocationNode : MonoBehaviour
    {
        [field: SerializeField] public Transform Input { get; private set; }
        [field: SerializeField] public Transform Output { get; private set; }
    }
}