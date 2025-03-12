using System;
using UnityEngine;

namespace Reflection
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float radius;
        [SerializeField] private Vector3 velocity;
        [SerializeField] private Transform wall;

        private bool _collidingWithWall;
        
        private Vector3 WallNormal => wall.up;

        private void FixedUpdate()
        {
            if (IsCollidingWithWall()) ReflectVelocity();
            MoveSphere();
        }

        private bool IsCollidingWithWall()
        {
            var distanceToWall = CalculateDistanceToWall();
            return distanceToWall <= radius;
        }

        private void MoveSphere()
        {
            transform.position += velocity;
        }

        private void ReflectVelocity()
        {
            var reflectedVelocity = velocity + 2 * Vector3.Dot(-velocity, WallNormal) * WallNormal;
            velocity = reflectedVelocity;
        }

        private float CalculateDistanceToWall()
        {
            var t = 
                Vector3.Dot(WallNormal, wall.transform.position - transform.position) /
                Vector3.Dot(WallNormal, WallNormal);

            return Mathf.Abs(t);
        }
    }
}
