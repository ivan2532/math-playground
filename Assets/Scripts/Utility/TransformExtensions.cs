using UnityEngine;

namespace Utility
{
    public static class TransformExtensions
    {
        public static void DestroyAllChildren(this Transform transform)
        {
            if (transform.childCount == 0) return;

            for (var i = transform.childCount - 1; i >= 0; i--)
            {
                Object.Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}