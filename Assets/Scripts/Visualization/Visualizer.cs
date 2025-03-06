using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Visualization
{
    public class Visualizer : MonoBehaviour
    {
        [SerializeField] private ShapeAsset shape;
        [SerializeField] private float sampleRate = 40f;

        private readonly List<GameObject> _generatedPoints = new();

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
            foreach (var pointObject in points.Select(CreatePoint))
            {
                _generatedPoints.Add(pointObject);
            }
        }

        private void CleanUp()
        {
            foreach (var point in _generatedPoints)
            {
                Destroy(point);
            }

            _generatedPoints.Clear();
        }
        
        private static GameObject CreatePoint(Vector3 position)
        {
            var pointObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            pointObject.transform.position = position;
            return pointObject;
        }
    }
}