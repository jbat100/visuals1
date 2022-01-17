using UnityEngine;

namespace Sonosthesia
{
    public class GroupOrchestrator : MonoBehaviour
    {
        protected virtual void OnEnable()
        {
            foreach (GraphBuilder graphBuilder in GetComponentsInChildren<GraphBuilder>())
            {
                Node rootNode = graphBuilder.GetOrAddComponent<Node>();
                graphBuilder.Build(rootNode);
            }

            foreach (GroupLerper groupLerper in GetComponentsInChildren<GroupLerper>())
            {
                groupLerper.Setup();
            }
        }
    }
}

