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

        public override LineIntersectionResult IntersectsAt(LineBase other)
        {
            var result =  base.IntersectsAt(other);
            if (result == null) return null;
            
            return result.T is < 0f or > 1f || result.S is < 0f or > 1f ? null : result;
        }
    }
}