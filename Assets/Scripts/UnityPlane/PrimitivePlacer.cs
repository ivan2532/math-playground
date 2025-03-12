using JetBrains.Annotations;
using UnityEngine;

namespace UnityPlane
{
    [RequireComponent(typeof(Camera))]
    public class PrimitivePlacer : MonoBehaviour
    {
        [SerializeField] private Transform ground;

        private readonly Primitive _cube = new Cube();
        private readonly Primitive _sphere = new Sphere();
        private Camera _camera;

        private Primitive _primitive;

        private Plane GroundPlane => new(ground.up, ground.position);

        private void Start()
        {
            Initialize();
            Select(_cube);
        }

        private void Update()
        {
            if (_primitive != null)
            {
                HandlePlacementInput();
                UpdatePlaceholder();
            }

            HandleSelectionInput();
        }

        private void Initialize()
        {
            _camera = GetComponent<Camera>();
            _cube.Initialize();
            _sphere.Initialize();
        }

        private void UpdatePlaceholder()
        {
            _primitive.UpdatePlaceholder(GetGroundPositionAtMousePosition(), GroundPlane.normal);
        }

        private void HandleSelectionInput()
        {
            if (Input.GetKeyDown(KeyCode.C)) Select(_cube);
            if (Input.GetKeyDown(KeyCode.S)) Select(_sphere);
            if (Input.GetKeyDown(KeyCode.X)) Select(null);
        }

        private void HandlePlacementInput()
        {
            if (Input.GetMouseButtonDown(0)) PlacePrimitiveAtMousePosition();
        }

        private void Select([CanBeNull] Primitive primitive)
        {
            _primitive?.HidePlaceholder();
            _primitive = primitive;
            _primitive?.ShowPlaceholder(GetGroundPositionAtMousePosition(), GroundPlane.normal);
        }

        private void PlacePrimitiveAtMousePosition()
        {
            _primitive.Place(GetGroundPositionAtMousePosition(), GroundPlane.normal);
        }

        private Vector3 GetGroundPositionAtMousePosition()
        {
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            return !GroundPlane.Raycast(ray, out var t) ? Vector3.zero : ray.GetPoint(t);
        }
    }
}