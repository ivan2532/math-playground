using Geometry;
using UnityEngine;

namespace Visualization
{
    [CreateAssetMenu(fileName = "Line", menuName = "Shapes/Line")]
    public class LineAsset : ShapeAsset
    {
        [field: SerializeField] public Vector3 A { get; private set; }
        [field: SerializeField] public Vector3 B { get; private set; }

        protected override IShape Shape => new Line(new TwoPointLineDescriptor(A, B));
    }
}