using UnityEngine;

namespace Sonosthesia
{
    public abstract class GraphBuilder : MonoBehaviour
    {
        [SerializeField] private GameObject _leafPrefab;
        [SerializeField] private GroupConfiguration _groupConfiguration;
        [SerializeField] private GraphConfiguration _graphConfiguration;
        [SerializeField] private bool _autoBuild;

        protected virtual void Awake()
        {
            if (_autoBuild)
            {
                Node rootNode = GetComponent<Node>();
                if (!rootNode)
                {
                    rootNode = gameObject.AddComponent<Node>();   
                }
                Build(rootNode);
            }
        }
        
        public void Build(Node root)
        {
            Build(root, _groupConfiguration, _graphConfiguration);

            if (_leafPrefab)
            {
                foreach (Node node in root.Leaves())
                {
                    GameObject leaf = Instantiate(_leafPrefab, node.transform);
                    leaf.name = "Leaf";
                }   
            }
        }

        protected abstract void Build(Node root, GroupConfiguration groupConfiguration, GraphConfiguration graphConfiguration);
    }    
}


