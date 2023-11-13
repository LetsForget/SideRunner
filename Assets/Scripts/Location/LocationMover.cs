using UnityEngine;

namespace Location
{
    public class LocationMover
    {
        private Transform location;
        private Vector3 direction;

        public float Speed { get; set; } = 5;
        public float SpeedMultiplier { get; set; } = 1;
        
        public LocationMover(Transform location, Vector3 direction)
        {
            this.location = location;
            this.direction = direction.normalized;
        }
        
        public void Update()
        {
            location.position += direction * (Speed * SpeedMultiplier * Time.deltaTime);
        }
    }
}