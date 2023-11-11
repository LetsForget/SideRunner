using UnityEngine;

namespace Movement
{
    [CreateAssetMenu(menuName = "Assets/Movement/Jump config", fileName = "Jump config")]
    public class JumpConfig : ScriptableObject
    {
        // jump settings
        [field: SerializeField] public AnimationCurve JumpCurve { get; private set; }
        [field: SerializeField] public float JumpHeight { get; private set; }
        [field: SerializeField] public float JumpTime { get; private set; }

        // fly settings
        [field: SerializeField] public float FlyTime { get; private set; }

        // land settings
        [field: SerializeField] public float LandTime { get; private set; }
        [field: SerializeField] public AnimationCurve LandCurve { get; private set; }
    }
}