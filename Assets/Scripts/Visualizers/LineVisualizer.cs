using System;
using System.Collections.Generic;
using Geometry;
using UnityEngine;

namespace Visualizers
{
    public class LineVisualizer : MonoBehaviour
    {
        [SerializeField] private LineType lineType;
        [SerializeField] private Transform a;
        [SerializeField] private Transform b;

        [SerializeField] private float sampleRate = 5f;
    
        private readonly List<GameObject> _generatedPoints = new();

        private const float MinusInfinity = -10f;
        private const float PlusInfinity = 10f;
    
        private void Start()
        {
            Generate();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                CleanUp();
                Generate();
            }
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
            GenerateCustomLine(MinusInfinity, PlusInfinity);
        }

        private void GenerateRay()
        {
            GenerateCustomLine(0f, PlusInfinity);
        }

        private void GenerateLineSegment()
        {
            GenerateCustomLine(0f, 1f);
        }

        private void GenerateCustomLine(float normalizedStart, float normalizedEnd)
        {
            var v = b.position - a.position;
        
            for (var t = normalizedStart; t <= normalizedEnd; t += 1f / sampleRate)
            {
                var pointPosition = a.position + v * t;
                var point = VisualizerUtils.CreatePoint(pointPosition);
                _generatedPoints.Add(point);
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