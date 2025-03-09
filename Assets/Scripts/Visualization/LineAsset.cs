using Geometry;
using UnityEngine;

namespace Visualization
{
    [CreateAssetMenu(fileName = "Line", menuName = "Shapes/Line")]
    public class LineAsset : ShapeAsset
    {
        [field: SerializeField] public Vector3 A { get; private set; }
        [field: SerializeField] public Vector3 B { get; private set; }

        public override IShape Shape => Line;
        public Line Line => new(new TwoPointLineDescriptor(A, B));
    }
}