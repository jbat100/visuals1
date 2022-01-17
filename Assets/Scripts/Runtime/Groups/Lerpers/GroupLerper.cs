using System.Collections.Generic;
using UnityEngine;

namespace Sonosthesia
{
    public class GroupLerper : MonoBehaviour
    {
        [SerializeField] private GroupConfiguration _groupConfiguration;
        [SerializeField] private List<Node> _targetRoots;
        [SerializeField] private NodeLerper _lerperPrefab;
        
        // this is a simple mechanism, may want to use in subclass and allow 
        [SerializeField] private float _lerp;        
        
        private readonly List<NodeLerper> _lerpers = new List<NodeLerper>();
        
        public void Setup()
        {
            int lerperCount = _groupConfiguration.Nodes;
            int targetCount = _targetRoots.Count;

            Node rootNode = GetComponent<Node>();
            if (!rootNode)
            {
                rootNode = gameObject.AddComponent<Node>();
            }

            Transform rootTransform = rootNode.transform;
            List<Node> targets = new List<Node>();

            // precompute descendants
            Dictionary<Node, List<Node>> _descendants = new Dictionary<Node, List<Node>>();
            foreach (Node targetRoot in _targetRoots)
            {
                _descendants[targetRoot] = new List<Node>(targetRoot.Descendants());
            }

            for (int lerperIndex = 0; lerperIndex < lerperCount; lerperIndex++)
            {
                targets.Clear();
                NodeLerper lerper = Instantiate(_lerperPrefab, rootTransform);
                for (int targetIndex = 0; targetIndex < targetCount; targetIndex++)
                {
                    Node targetRoot = _targetRoots[targetIndex];
                    targets.Add(_descendants[targetRoot][lerperIndex]);
                }
                lerper.SetTargets(targets);
                _lerpers.Add(lerper);
            }
        }

        protected virtual void Update()
        {
            int lerperCount = _lerpers.Count;
            int index = Mathf.FloorToInt(_lerp);
            float remainder = _lerp - index;
            int first = Mathf.FloorToInt(lerperCount * remainder);
            Debug.Log($"{this} setting {nameof(index)} {index} up to {first} then {index+1} up to {lerperCount}");
            for (int lerperIndex = 0; lerperIndex < first; lerperIndex++)
            {
                _lerpers[lerperIndex].Index = index;
            }
            index++;
            for (int lerperIndex = first; lerperIndex < lerperCount; lerperIndex++)
            {
                _lerpers[lerperIndex].Index = index;
            }
        }
    }    
}


