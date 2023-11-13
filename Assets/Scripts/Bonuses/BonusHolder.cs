using UnityEngine;

namespace GameInput.Bonuses
{
    public class BonusHolder : MonoBehaviour
    {
        [field: SerializeField] public BonusData Data { get; private set; } 
    }
}