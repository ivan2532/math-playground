using UnityEngine;

public class LookAt2D : MonoBehaviour
{
    [SerializeField] private Transform a;
    [SerializeField] private Transform b;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) LookAtB();
    }

    private void LookAtB()
    {
        // First determine if the sign of the angle
        var aToB = b.position - a.position;
        var forward = a.up;
        var cross = Vector3.Cross(forward, aToB);
        var sgnTheta = cross.z > 0f ? 1f : -1f;
        
        // Determine the absolute value of theta
        var dot = Vector3.Dot(aToB, forward);
        var absTheta = Mathf.Acos(dot / (aToB.magnitude * forward.magnitude));
        
        // Now we have theta
        var theta = sgnTheta * absTheta;
        
        // Rotate object A
        a.Rotate(Vector3.forward, theta * Mathf.Rad2Deg, Space.Self);
    }
}
