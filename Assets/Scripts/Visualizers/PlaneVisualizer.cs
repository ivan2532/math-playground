using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Plane = Geometry.Plane;

namespace Visualizers
{
    public class PlaneVisualizer : MonoBehaviour
    {
        [SerializeField] private Transform a;
        [SerializeField] private Transform b;
        [SerializeField] private Transform c;

        [SerializeField] private float sampleRate = 40f;

        private readonly List<GameObject> _generatedPoints = new();

        private void Start()
        {
            Generate();
        }

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
            var plane = new Plane(a.position, b.position, c.position);
            var points = plane.Sample(sampleRate);
            
            foreach (var pointObject in points.Select(VisualizerUtils.CreatePoint))
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
    }
}