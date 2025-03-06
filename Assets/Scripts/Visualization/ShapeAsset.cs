using System.Collections.Generic;
using Geometry;
using UnityEngine;

namespace Visualization
{
    public abstract class ShapeAsset : ScriptableObject
    {
        protected abstract IShape Shape { get; }

        public List<Vector3> Sample(float rate)
        {
            return Shape.Sample(rate);
        }
    }
}