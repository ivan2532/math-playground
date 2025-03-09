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

        [CanBeNull]
        public virtual LineIntersectionResult IntersectsAt(LineBase other)
        {
            var c = other.A - A;
            var planeNormal = Vector3.Cross(V, other.V);

            var parallelLines = planeNormal == Vector3.zero;
            if (parallelLines) return null;

            var coplanarLines = Vector3.Dot(c, planeNormal) == 0f;
            if (!coplanarLines) return null;

            var vPerp = V.GetPerpendicularVector(planeNormal);
            var uPerp = other.V.GetPerpendicularVector(planeNormal);

            var tDivider = Vector3.Dot(uPerp, V);
            var sDivider = -Vector3.Dot(vPerp, other.V);

            var t = Vector3.Dot(uPerp, c) / tDivider;
            var s = Vector3.Dot(vPerp, c) / sDivider;

            return new LineIntersectionResult(A + V * t, t, s);
        }
    }
}