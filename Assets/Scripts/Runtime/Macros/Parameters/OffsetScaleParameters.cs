using System;
using UnityEngine;

namespace Sonosthesia
{
    [Serializable]
    public class OffsetScaleParameters : IOffsetParameters, IScaleParameters
    {
        [SerializeField] private float _factor = 1f;
        public float Scale => _factor;
    
        [SerializeField] private float _offset = 0f;
        public float Offset => _offset;
    }
}