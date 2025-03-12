using UnityEngine;

namespace UnityPlane
{
    public abstract class Primitive
    {
        private GameObject _placeholder;

        public void Initialize()
        {
            _placeholder = CreatePrimitive();
            HidePlaceholder();
        }

        public void Place(Vector3 groundPosition, Vector3 groundNormal)
        {
            var primitive = CreatePrimitive();
            primitive.transform.position = CalculatePlacementPosition(groundPosition, groundNormal);
        }

        public void UpdatePlaceholder(Vector3 groundPosition, Vector3 groundNormal)
        {
            _placeholder.transform.position = CalculatePlacementPosition(groundPosition, groundNormal);
        }

        public void ShowPlaceholder(Vector3 groundPosition, Vector3 groundNormal)
        {
            UpdatePlaceholder(groundPosition, groundNormal);
            ShowPlaceholder();
        }

        public void ShowPlaceholder()
        {
            _placeholder.SetActive(true);
        }

        public void HidePlaceholder()
        {
            _placeholder.SetActive(false);
        }

        protected abstract GameObject CreatePrimitive();

        protected abstract Vector3 CalculatePlacementPosition(Vector3 groundPosition, Vector3 groundNormal);
    }
}