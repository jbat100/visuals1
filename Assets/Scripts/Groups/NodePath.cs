using System.Collections.Generic;
using UnityEngine;

namespace Sonosthesia
{
    public enum NodePathSelection
    {
        None,
        Self,
        Leaves,
        Children,
        Descendants
    }
    
    public class NodePath
    {
        [SerializeField] private List<int> _path;
        public int[] Path => _path.ToArray();

        [SerializeField] private NodePathSelection _selection;
        public NodePathSelection Selection => _selection;
    }    
    
    public static class NodePathExtensions
    {
        public static IEnumerable<Node> Query(this Node node, NodePath path)
        {
            HashSet<Node> nodes = new HashSet<Node>();
            node.Query(path, nodes);
            return nodes;
        }

        public static void Query(this Node node, NodePath path, HashSet<Node> nodes)
        {
            node.GetDescendantAtPath(path.Path);
            node.Selection(path.Selection, nodes);
        }
    }
}

