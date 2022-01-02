using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonosthesia
{
    [CreateAssetMenu(fileName = "GraphConfiguration", menuName = "Sonosthesia/GraphConfiguration")]
    public class GraphConfiguration : ScriptableObject
    {
        [SerializeField] private int _nodes;
        public int Nodes => _nodes;
    }    
}


