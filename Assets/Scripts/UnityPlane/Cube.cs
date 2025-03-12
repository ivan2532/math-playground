using UnityEngine;

namespace UnityPlane
{
    public class Cube : Primitive
    {
        private const float Height = 1f;
        
        protected override GameObject CreatePrimitive()
        {
            return GameObject.CreatePrimitive(PrimitiveType.Cube);
        }

        protected override Vector3 CalculatePlacementPosition(Vector3 groundPosition, Vector3 groundNormal)
        {
            return groundPosition + Height / 2f * Vector3.up;
        }
    }
}