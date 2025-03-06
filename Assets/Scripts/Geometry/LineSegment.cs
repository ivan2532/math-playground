using System.Collections.Generic;
using UnityEngine;

namespace Geometry
{
    public class LineSegment : IShape
    {
        private readonly Vector3 _a;
        private readonly Vector3 _v;
        
        public LineSegment(Vector3 a, Vector3 b)
        {
            _a = a;
            _v = b - a;
        }

        public List<Vector3> Sample(float rate)
        {
            var points = new List<Vector3>();
            
            for (var t = 0f; t <= 1f; t += 1f / rate)
            {
                points.Add(_a + _v * t);
            }

            return points;
        }
    }
}