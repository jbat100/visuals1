using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Sonosthesia
{
    public class LayerGraphBuilder : GraphBuilder
    {
        protected override void Build(Node root, GraphConfiguration configuration)
        {
            LayerGraphConfiguration layerGraphConfiguration = (LayerGraphConfiguration)configuration;
            int nodes = layerGraphConfiguration.Nodes;
            int layerNodes = layerGraphConfiguration.LayerNodes;
            Vector3 positionOffset = layerGraphConfiguration.PositionOffset;
            
            int count = 0;
            int layerIndex = 0;
            Vector3 localPosition = Vector3.zero;
            while (count < nodes)
            {
                Node child = root.CreateChild();
                child.transform.localPosition = localPosition;
                BuildLayer(child, layerIndex, Mathf.Min(layerNodes, nodes - count));
                count += layerNodes;
                layerIndex++;
                localPosition += positionOffset;
            }
        }

        protected virtual void BuildLayer(Node root, int layerIndex, int layerNodes)
        {
            
        }
    }
}
