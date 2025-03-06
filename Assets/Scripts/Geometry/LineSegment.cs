using System.Collections.Generic;
using UnityEngine;

namespace Geometry
{
    public class LineSegment : LineBase
    {
        protected override float NormalizedStart => 0f;
        protected override float NormalizedEnd => 1f;
        
        public LineSegment(TwoPointLineDescriptor descriptor) : base(descriptor)
        {
        }

        public LineSegment(StartAndDirectionLineDescriptor descriptor) : base(descriptor)
        {
        }
    }
}