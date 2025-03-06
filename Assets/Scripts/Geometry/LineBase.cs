using System.Collections.Generic;
using UnityEngine;

namespace Geometry
{
    public abstract class LineBase : IShape
    {
        protected abstract float NormalizedStart { get; }
        protected abstract float NormalizedEnd { get; }
        
        private readonly Vector3 _a;
        private readonly Vector3 _v;

        private const float Infinity = 10f;

        protected LineBase(TwoPointLineDescriptor descriptor)
        {
            _a = descriptor.A;
            _v = descriptor.B - descriptor.A;
        }
        
        protected LineBase(StartAndDirectionLineDescriptor descriptor)
        {
            _a = descriptor.A;
            _v = descriptor.V;
        }

        public List<Vector3> Sample(float rate)
        {
            var points = new List<Vector3>();
            
            for (var t = NormalizedStart; t <= NormalizedEnd; t += 1f / rate)
            {
                points.Add(_a + _v * t);
            }

            return points;
        }
    }
}