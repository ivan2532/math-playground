using System;
using System.Linq;
using UnityEngine;
using Utility;

namespace Visualization
{
    public class Visualizer : MonoBehaviour
    {
        [SerializeField] private ShapeAsset shape;
        [SerializeField] private float sampleRate = 40f;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) Regenerate();
        }

        private void Regenerate()
        {
            CleanUp();
            Generate();
        }

        private void Generate()
        {
            if (shape == null)
            {
                throw new ArgumentNullException(nameof(shape));
            }
            
            var points = shape.Sample(sampleRate);
            var pointNumber = 1;
            
            foreach (var pointObject in points.Select(CreatePoint))
            {
                pointObject.transform.SetParent(transform, true);
                pointObject.name = $"Point {pointNumber}";
                pointNumber++;
            }
        }

        private void CleanUp()
        {
            transform.DestroyAllChildren();
        }
        
        private static GameObject CreatePoint(Vector3 position)
        {
            var pointObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            pointObject.transform.position = position;
            return pointObject;
        }
    }
}