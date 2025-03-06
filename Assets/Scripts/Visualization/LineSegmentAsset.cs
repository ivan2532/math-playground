using Geometry;
using UnityEngine;

namespace Visualization
{
    [CreateAssetMenu(fileName = "LineSegment", menuName = "Shapes/Line Segment")]
    public class LineSegmentAsset : ShapeAsset
    {
        [SerializeField] private Vector3 a;
        [SerializeField] private Vector3 b;
        
        protected override IShape Shape => new LineSegment(a, b);
    }
}