using System;
using System.Collections.Generic;
using System.Linq;
using Geometry;
using UnityEngine;
using Ray = Geometry.Ray;

namespace Visualizers
{
    public class LineVisualizer : MonoBehaviour
    {
        [SerializeField] private LineType lineType;
        [SerializeField] private Transform a;
        [SerializeField] private Transform b;

        [SerializeField] private float sampleRate = 5f;
    
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
            switch (lineType)
            {
                case LineType.Line:
                    GenerateLine();
                    break;
                case LineType.Ray:
                    GenerateRay();
                    break;
                case LineType.LineSegment:
                    GenerateLineSegment();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void GenerateLine()
        {
            var line = new Line(a.position, b.position);
            var points = line.Sample(sampleRate);
            
            foreach (var pointObject in points.Select(VisualizerUtils.CreatePoint))
            {
                _generatedPoints.Add(pointObject);
            }
        }

        private void GenerateRay()
        {
            var line = new Ray(a.position, b.position);
            var points = line.Sample(sampleRate);
            
            foreach (var pointObject in points.Select(VisualizerUtils.CreatePoint))
            {
                _generatedPoints.Add(pointObject);
            }
        }

        private void GenerateLineSegment()
        {
            var line = new LineSegment(a.position, b.position);
            var points = line.Sample(sampleRate);
            
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