using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Utility;

namespace Geometry
{
    public abstract class LineBase : IShape
    {
        public readonly Vector3 A;
        public readonly Vector3 V;

        protected abstract float NormalizedStart { get; }
        protected abstract float NormalizedEnd { get; }

        protected LineBase(TwoPointLineDescriptor descriptor)
        {
            A = descriptor.A;
            V = descriptor.B - descriptor.A;
        }

        protected LineBase(StartAndDirectionLineDescriptor descriptor)
        {
            A = descriptor.A;
            V = descriptor.V;
        }

        public List<Vector3> Sample(float rate)
        {
            var points = new List<Vector3>();

            for (var t = NormalizedStart; t <= NormalizedEnd; t += 1f / rate)
            {
                points.Add(A + V * t);
            }

            return points;
        }
    }
}