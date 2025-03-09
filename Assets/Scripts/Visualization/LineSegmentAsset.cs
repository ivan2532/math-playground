using Geometry;
using UnityEngine;

namespace Visualization
{
    [CreateAssetMenu(fileName = "LineSegment", menuName = "Shapes/Line Segment")]
    public class LineSegmentAsset : ShapeAsset
    {
        [field: SerializeField] public Vector3 A { get; private set; }
        [field: SerializeField] public Vector3 B { get; private set; }
        
        protected override IShape Shape => new LineSegment(new TwoPointLineDescriptor(A, B));
    }
}