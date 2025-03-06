using Geometry;
using UnityEngine;
using Ray = Geometry.Ray;

namespace Visualization
{
    [CreateAssetMenu(fileName = "Ray", menuName = "Shapes/Ray")]
    public class RayAsset : ShapeAsset
    {
        [SerializeField] private Vector3 a;
        [SerializeField] private Vector3 b;
        
        protected override IShape Shape => new Ray(a, b);
    }
}