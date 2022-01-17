using System;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Sonosthesia
{
    // wondering if we can't just get away with transforms, but keeping the two notions separate can give more flexibilty 
    
    public class Node : MonoBehaviour
    {
        private readonly List<Node> _children = new List<Node>();

        public bool IsLeaf => _children.Count == 0;
        
        public Node GetChild(int i)
        {
            if (i < 0 || i >= _children.Count)
            {
                throw new ArgumentOutOfRangeException($"bad child index {i}, node has {_children.Count} children");
            }
            return _children[i];
        }

        public Node GetDescendantAtPath(params int[] path)
        {
            return path.Aggregate(this, (current, i) => current.GetChild(i));
        }

        public IEnumerable<Node> Descendants()
        {
            yield return this;
            foreach (Node descendant in _children.SelectMany(child => child.Descendants()))
            {
                yield return descendant;
            }
        }

        public IEnumerable<Node> Leaves() => Descendants().Where(descendant => descendant.IsLeaf);

        public Node CreateChild()
        {
            GameObject childObject = new GameObject("Node");
            childObject.transform.parent = transform;
            return CreateChild(childObject);
        }

        public Node CreateChild(GameObject childObject)
        {
            Node childNode = childObject.AddComponent<Node>();
            AddChild(childNode);
            return childNode;
        }

        public void AddChild(Node node)
        {
            _children.Add(node);
        }

        public void Selection(NodePathSelection selection, HashSet<Node> nodes)
        {
            switch (selection)
            {
                case NodePathSelection.Children:
                    nodes.AddRange(_children);
                    return;
                case NodePathSelection.Descendants:
                    nodes.AddRange(Descendants());
                    return;
                case NodePathSelection.Leaves:
                    nodes.AddRange(Leaves());
                    return;
                case NodePathSelection.Self:
                    nodes.Add(this);
                    return;
                default:
                    return;
            }
        }

        private TransformMonitor _transformMonitor;
        public TransformMonitor TransformMonitor
        {
            get
            {
                if (!_transformMonitor)
                {
                    _transformMonitor = this.GetOrAddComponent<TransformMonitor>();
                }
                return _transformMonitor;
            }
        }
    }
}


