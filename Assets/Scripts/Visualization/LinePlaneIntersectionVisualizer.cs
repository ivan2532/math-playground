using System;
using Geometry;
using UnityEngine;
using Plane = Geometry.Plane;

namespace Visualization
{
    public class LinePlaneIntersectionVisualizer : MonoBehaviour
    {
        [SerializeField] private LineSegmentAsset lineSegmentAsset;
        [SerializeField] private PlaneAsset planeAsset;

        private Transform _intersectionTransform;

        private LineSegment LineSegment => lineSegmentAsset.LineSegment;
        private Plane Plane => planeAsset.Plane;

        private void Awake()
        {
            _intersectionTransform = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
        }

        private void Update()
        {
            var t = CalculateIntersectionT();
            _intersectionTransform.position = LineSegment.A + LineSegment.V * t;
        }

        private float CalculateIntersectionT()
        {
            var divider = Vector3.Dot(Plane.Normal, LineSegment.V);
            if (divider == 0f) return 0f;

            var t = Vector3.Dot(Plane.Normal, Plane.A - lineSegmentAsset.A) / divider;
            return t is >= 0 and <= 1 ? t : 0f;
        }
    }
}