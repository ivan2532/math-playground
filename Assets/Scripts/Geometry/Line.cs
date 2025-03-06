namespace Geometry
{
    public class Line : LineBase
    {
        protected override float NormalizedStart => -Infinity;
        protected override float NormalizedEnd => Infinity;

        private const float Infinity = 10f;
        
        public Line(TwoPointLineDescriptor descriptor) : base(descriptor)
        {
        }

        public Line(StartAndDirectionLineDescriptor descriptor) : base(descriptor)
        {
        }
    }
}