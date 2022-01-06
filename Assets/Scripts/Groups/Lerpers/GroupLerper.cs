using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonosthesia
{
    public class GroupLerper : MonoBehaviour
    {
        [SerializeField] private GroupConfiguration _groupConfiguration;
        [SerializeField] private List<Node> _nodes;
        [SerializeField] private GameObject _prefab;
        
        // this is a simple mechanism, may want to use in subclass and allow 
        [SerializeField] private float _lerp;

        protected virtual void Start()
        {
            int nodes = _groupConfiguration.Nodes;

            Node rootNode = GetComponent<Node>();
            if (!rootNode)
            {
                rootNode = gameObject.AddComponent<Node>();
            }

            for (int i = 0; i < nodes; i++)
            {
                
            }
        }


    }    
}


