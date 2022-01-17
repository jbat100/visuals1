using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sonosthesia
{
    public class NodeMacroTarget : MacroTarget
    {
        [SerializeField] private List<NodePath> _nodePaths;
        [SerializeField] private Node _root;

        private readonly HashSet<Node> _nodes = new HashSet<Node>();

        protected class NodeProcessor : MacroProcessor
        {
            protected readonly Node _node;
            public NodeProcessor(Node node, IProcessorParameters parameters) : base(parameters)
            {
                _node = node;
            }
        }

        protected virtual NodeProcessor CreateProcessor(Node node)
        {
            throw new NotImplementedException();
        }

        protected virtual void Start()
        { 
            foreach (NodePath nodePath in _nodePaths)
            {
                _root.Query(nodePath, _nodes);    
            }

            foreach (Node node in _nodes)
            {
                NodeProcessor processor = CreateProcessor(node);
                processor.Setup();
                RegisterProcessor(processor);
            }
        }
    } 
}