using System;
using UnityEngine;

namespace Utility
{
    public static class VectorExtensions
    {
        public static Vector2 Perpendicular(this Vector2 vector)
        {
            if (vector == Vector2.zero)
            {
                throw new ArgumentException(
                    "Can't find perpendicular vector of a zero vector.", nameof(vector));
            }
            
            return new Vector2(-vector.y, vector.x);
        }

        public static Vector3 Perpendicular(this Vector3 vector)
        {
            if (vector == Vector3.zero)
            {
                throw new ArgumentException(
                    "Can't find perpendicular vector of a zero vector.", nameof(vector));
            }

            return vector is { x: 0f, y: 0f } 
                ? new Vector3(vector.z, 0f, 0f) 
                : new Vector3(-vector.y, vector.x, 0f);
        }
    }
}