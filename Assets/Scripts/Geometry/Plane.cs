using System.Collections.Generic;
using UnityEngine;

namespace Geometry
{
    public class Plane
    {
        private readonly Vector3 _a;
        private readonly Vector3 _u;
        private readonly Vector3 _v;
        
        public Plane(Vector3 a, Vector3 b, Vector3 c)
        {
            _a = a;
            _v = b - a;
            _u = c - a;
        }

        public List<Vector3> Sample(float rate)
        {
            var points = new List<Vector3>();

            for (var t = 0f; t < 1f || Mathf.Approximately(t, 1f); t += 1f / rate)
            {
                for (var s = 0f; s < 1f || Mathf.Approximately(s, 1f); s += 1f / rate)
                {
                    points.Add(_a + _v * t + _u * s);
                }
            }

            return points;
        }
    }
}