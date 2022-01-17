using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonosthesia
{
    [CreateAssetMenu(fileName = "LayerGraphConfiguration", menuName = "Sonosthesia/LayerGraphConfiguration")]
    public class LayerGraphConfiguration : GraphConfiguration
    {
        [SerializeField] private int _layerNodes;
        public int LayerNodes => _layerNodes;

        [SerializeField] private Vector3 _positionOffset;
        public Vector3 PositionOffset => _positionOffset;
    }
}
