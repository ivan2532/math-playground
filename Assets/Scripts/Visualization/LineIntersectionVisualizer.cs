using Geometry;
using UnityEngine;

namespace Visualization
{
    public class LineIntersectionVisualizer : MonoBehaviour
    {
        [SerializeField] private LineSegmentAsset lineSegmentAsset1;
        [SerializeField] private LineSegmentAsset lineSegmentAsset2;

        private Transform _intersectionTransform;

        private LineSegment LineSegment1 => lineSegmentAsset1.LineSegment;
        private LineSegment LineSegment2 => lineSegmentAsset2.LineSegment;
        
        private void Awake()
        {
            _intersectionTransform = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
        }

        private void Update()
        {
            var intersectionResult = LineSegment1.IntersectsAt(LineSegment2);
            _intersectionTransform.position = intersectionResult?.Point ?? LineSegment1.A;
        }
    }
}