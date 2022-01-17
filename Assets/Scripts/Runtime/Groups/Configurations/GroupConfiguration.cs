using UnityEngine;

namespace Sonosthesia
{
    [CreateAssetMenu(fileName = "GroupConfiguration", menuName = "Sonosthesia/GroupConfiguration")]
    public class GroupConfiguration : ScriptableObject
    {
        [SerializeField] private int _nodes;
        public int Nodes => _nodes;
    }
    
}
