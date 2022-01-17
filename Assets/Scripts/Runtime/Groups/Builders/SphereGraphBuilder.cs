using UnityEngine;

namespace Sonosthesia
{
    public class SphereGraphBuilder : GraphBuilder
    {
        protected override void Build(Node root, GroupConfiguration groupConfiguration, GraphConfiguration graphConfiguration)
        {
            int nodes = groupConfiguration.Nodes;
            for (int i = 0; i < nodes; i++)
            {
                Vector3 position = FibonacciSphere(i, nodes);
                Quaternion rotation = Quaternion.LookRotation(position);
                Node node = root.CreateChild();
                node.transform.localPosition = position;
                node.transform.localRotation = rotation;
            }
        }
        
        // https://medium.com/@vagnerseibert/distributing-points-on-a-sphere-6b593cc05b42
        private Vector3 FibonacciSphere(int index, int count) {
            float k = index + .5f;
            float phi = Mathf.Acos(1f - 2f * k / count);
            float theta = Mathf.PI * (1 + Mathf.Sqrt(5)) * k;
            float x = Mathf.Cos(theta) * Mathf.Sin(phi);
            float y = Mathf.Sin(theta) * Mathf.Sin(phi);
            float z = Mathf.Cos(phi);
            return new Vector3(x, y, z);
        }
        
    }
}


