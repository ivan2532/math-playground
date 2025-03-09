using Geometry;
using UnityEngine;
using Plane = Geometry.Plane;

namespace Visualization
{
    [CreateAssetMenu(fileName = "Plane", menuName = "Shapes/Plane")]
    public class PlaneAsset : ShapeAsset
    {
        [field: SerializeField] public Vector3 A { get; private set; }
        [field: SerializeField] public Vector3 B { get; private set; }
        [field: SerializeField] public Vector3 C { get; private set; }

        public override IShape Shape => Plane;
        public Plane Plane => new(A, B, C);
    }
}