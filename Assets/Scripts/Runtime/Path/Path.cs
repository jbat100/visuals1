using UnityEngine;

namespace Sonosthesia
{
    public abstract class Path : MonoBehaviour
    {
        public abstract Vector3 Position(float distance, bool normalized);
    
        public abstract Quaternion Rotation(float distance, bool normalized);
    }
}

