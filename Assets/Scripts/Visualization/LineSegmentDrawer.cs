using UnityEngine;

namespace Visualization
{
    [RequireComponent(typeof(LineRenderer))]
    public class LineSegmentDrawer : MonoBehaviour
    {
        [SerializeField] private LineSegmentAsset lineSegment;

        private LineRenderer _lineRenderer;

        private void Awake()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _lineRenderer.positionCount = 2;
        }

        private void Update()
        {
            Draw();
        }

        private void Draw()
        {
            _lineRenderer.SetPosition(0, lineSegment.A);
            _lineRenderer.SetPosition(1, lineSegment.B);
        }
    }
}