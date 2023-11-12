using UnityEngine;

namespace Location
{
    public class LocationMover
    {
        private Transform location;
        private Vector3 direction;

        public float MoveSpeed { get; set; } = 3;

        public LocationMover(Transform location, Vector3 direction)
        {
            this.location = location;
            this.direction = direction.normalized;
        }
        
        public void Update()
        {
            location.position += direction * (MoveSpeed * Time.deltaTime);
        }
    }
}