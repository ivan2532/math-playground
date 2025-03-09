using Geometry;
using UnityEngine;

namespace Visualization
{
    [CreateAssetMenu(fileName = "LineSegment", menuName = "Shapes/Line Segment")]
    public class LineSegmentAsset : ShapeAsset
    {
        [field: SerializeField] public Vector3 A { get; private set; }
        [field: SerializeField] public Vector3 B { get; private set; }

        public override IShape Shape => LineSegment;
        public LineSegment LineSegment => new(new TwoPointLineDescriptor(A, B));
    }
}