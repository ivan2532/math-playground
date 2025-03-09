using System;
using UnityEngine;

namespace Utility
{
    public static class VectorExtensions
    {
        public static Vector2 GetPerpendicularVector(this Vector2 vector)
        {
            if (vector == Vector2.zero)
            {
                throw new ArgumentException($"{nameof(vector)} must be a non zero vector.");
            }

            return new Vector2(-vector.y, vector.x).normalized;
        }
        
        public static Vector3 GetPerpendicularVector(this Vector3 vector, Vector3 planeNormal)
        {
            if (vector == Vector3.zero || planeNormal == Vector3.zero)
            {
                throw new ArgumentException(
                    $"{nameof(vector)} and {nameof(planeNormal)} must be non zero vectors.");
            }

            return Vector3.Cross(planeNormal, vector).normalized;
        }
    }
}