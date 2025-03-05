using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CleanUp();
            Generate();
        }
    }

    private void Generate()
    {
        var v = b.position - a.position;
        var u = c.position - a.position;

        for (var t = 0f; t < 1f || Mathf.Approximately(t, 1f); t += 1f / sampleRate)
        {
            for (var s = 0f; s < 1f || Mathf.Approximately(s, 1f); s += 1f / sampleRate)
            {
                var pointPosition = a.position + v * t + u * s;
                var point = VisualizerUtils.CreatePoint(pointPosition);
                _generatedPoints.Add(point);
            }
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
