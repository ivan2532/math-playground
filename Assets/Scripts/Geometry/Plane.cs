using System.Collections.Generic;
using UnityEngine;

namespace Geometry
{
    public class Plane : IShape
    {
        public readonly Vector3 A;
        public readonly Vector3 U;
        public readonly Vector3 V;
        
        public Vector3 Normal => Vector3.Cross(U, V).normalized;
        
        public Plane(Vector3 a, Vector3 b, Vector3 c)
        {
            A = a;
            V = b - a;
            U = c - a;
        }

        public List<Vector3> Sample(float rate)
        {
            var points = new List<Vector3>();

            for (var t = 0f; t < 1f || Mathf.Approximately(t, 1f); t += 1f / rate)
            {
                for (var s = 0f; s < 1f || Mathf.Approximately(s, 1f); s += 1f / rate)
                {
                    points.Add(A + V * t + U * s);
                }
            }

            return points;
        }
    }
}