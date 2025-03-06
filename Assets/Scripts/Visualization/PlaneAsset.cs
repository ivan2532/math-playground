using Geometry;
using UnityEngine;
using Plane = Geometry.Plane;

namespace Visualization
{
    [CreateAssetMenu(fileName = "Plane", menuName = "Shapes/Plane")]
    public class PlaneAsset : ShapeAsset
    {
        [SerializeField] private Vector3 a;
        [SerializeField] private Vector3 b;
        [SerializeField] private Vector3 c;
        
        protected override IShape Shape => new Plane(a, b, c);
    }
}