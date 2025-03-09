using Geometry;
using UnityEngine;
using Ray = Geometry.Ray;

namespace Visualization
{
    [CreateAssetMenu(fileName = "Ray", menuName = "Shapes/Ray")]
    public class RayAsset : ShapeAsset
    {
        [field: SerializeField] public Vector3 A { get; private set; }
        [field: SerializeField] public Vector3 B { get; private set; }
        
        protected override IShape Shape => new Ray(new TwoPointLineDescriptor(A, B));
    }
}