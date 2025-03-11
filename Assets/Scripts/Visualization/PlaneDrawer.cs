using System;
using UnityEngine;
using Plane = Geometry.Plane;

namespace Visualization
{
    public class PlaneDrawer : MonoBehaviour
    {
        [SerializeField] private PlaneAsset planeAsset;
        [SerializeField] private Transform planeMesh;

        private Plane Plane => planeAsset.Plane;

        private void Update()
        {
            Draw();
        }

        private void Draw()
        {
            planeMesh.position = Plane.A;
            planeMesh.up = Plane.Normal;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(planeAsset.A, 0.5f);
            Gizmos.DrawSphere(planeAsset.B, 0.5f);
            Gizmos.DrawSphere(planeAsset.C, 0.5f);
        }
    }
}