using UnityEngine;

namespace Movement.Jump
{
    [CreateAssetMenu(menuName = "Assets/Movement/Jump config", fileName = "Jump config")]
    public class JumpConfig : ScriptableObject
    {
        /// <summary>
        /// The ease of the lifting phase
        /// </summary>
        [field: SerializeField] public AnimationCurve JumpCurve { get; private set; }
        /// <summary>
        /// The height of the jump
        /// </summary>
        [field: SerializeField] public float JumpHeight { get; private set; }
        /// <summary>
        /// Duration of the lifting phase
        /// </summary>
        [field: SerializeField] public float JumpTime { get; private set; }

        /// <summary>
        /// The time for which the transform will hang in the air
        /// </summary>
        [field: SerializeField] public float FlyTime { get; private set; }
        
        /// <summary>
        /// Duration of the falling phase
        /// </summary>
        [field: SerializeField] public float LandTime { get; private set; }
        /// <summary>
        /// The ease of the falling phase
        /// </summary>
        [field: SerializeField] public AnimationCurve LandCurve { get; private set; }
    }
}