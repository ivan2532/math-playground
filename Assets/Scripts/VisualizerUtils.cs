using UnityEngine;

public static class VisualizerUtils
{
    public static GameObject CreatePoint(Vector3 position)
    {
        var pointObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        pointObject.transform.position = position;
        return pointObject;
    }
}