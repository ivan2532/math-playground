namespace Geometry
{
    public class Ray : LineBase
    {
        protected override float NormalizedStart => 0f;
        protected override float NormalizedEnd => Infinity;
        
        private const float Infinity = 10f;
        
        public Ray(TwoPointLineDescriptor descriptor) : base(descriptor)
        {
        }

        public Ray(StartAndDirectionLineDescriptor descriptor) : base(descriptor)
        {
        }

        public override LineIntersectionResult IntersectsAt(LineBase other)
        {
            var result =  base.IntersectsAt(other);
            if (result == null) return null;
            
            return result.T < 0f ? null : result;
        }
    }
}