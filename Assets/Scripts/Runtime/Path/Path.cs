using UnityEngine;

namespace Sonosthesia
{
    public abstract class Path : MonoBehaviour
    {
        public abstract Vector3 Position(float distance);
    
        public abstract Quaternion Rotation(float distance);
    }
}

