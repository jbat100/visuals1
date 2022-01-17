using UnityEngine;

namespace Sonosthesia
{
    public class CircularLayerGraphBuilder : LayerGraphBuilder
    {
        private const float TWO_PI = Mathf.PI * 2;
        
        protected override void BuildLayer(Node root, int layerIndex, int layerNodes)
        {
            float angleStep = TWO_PI  / layerNodes;
            float angle = 0f;
            for (int i = 0; i < layerNodes; i++)
            {
                Node child = root.CreateChild();
                Vector3 localPosition = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle));
                child.transform.localPosition = localPosition;
                child.transform.localRotation = Quaternion.LookRotation(localPosition, Vector3.up);
                angle += angleStep;
            }
        }
    }
}
