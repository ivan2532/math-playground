using Geometry;
using UnityEngine;

namespace Visualization
{
    [CreateAssetMenu(fileName = "Line", menuName = "Shapes/Line")]
    public class LineAsset : ShapeAsset
    {
        [SerializeField] private Vector3 a;
        [SerializeField] private Vector3 b;

        protected override IShape Shape => new Line(new TwoPointLineDescriptor(a, b));
    }
}