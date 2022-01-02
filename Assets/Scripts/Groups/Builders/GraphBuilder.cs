using UnityEngine;

namespace Sonosthesia
{
    public class GraphBuilder : MonoBehaviour
    {
        [SerializeField] private GameObject _leafPrefab;
        [SerializeField] private GraphConfiguration _configuration;
        [SerializeField] private bool _autoBuild;

        protected virtual void Awake()
        {
            if (_autoBuild)
            {
                GameObject rootObject = new GameObject("Root");
                rootObject.transform.parent = transform;
                Node rootNode = rootObject.AddComponent<Node>();
                Build(rootNode);
            }
        }
        
        public void Build(Node root)
        {
            Build(root, _configuration);

            if (_leafPrefab)
            {
                foreach (Node node in root.Leaves())
                {
                    GameObject leaf = Instantiate(_leafPrefab, node.transform);
                    leaf.name = "Leaf";
                }   
            }
        }

        protected virtual void Build(Node root, GraphConfiguration configuration)
        {
            
        }
    }    
}


