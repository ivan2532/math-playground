using System.Collections.Generic;
using UnityEngine;

namespace Geometry
{
    public interface IShape
    {
        public List<Vector3> Sample(float rate);
    }
}