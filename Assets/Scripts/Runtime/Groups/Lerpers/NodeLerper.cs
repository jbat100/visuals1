using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Sonosthesia
{
    public class NodeLerper : MonoBehaviour
    {
        [SerializeField] private float _duration = 1f;
        [SerializeField] private float _minTransferVelocity = 1f;
        [SerializeField] private Ease _ease = Ease.InOutQuad;
        [SerializeField] private bool _logIndex;

        private float _transfer;
        
        private int? _previousIndex;
        private int? _index;
        public int Index
        {
            get => _index ?? 0;
            set
            {
                if (_logIndex) Debug.Log($"{this} set {nameof(Index)} to {value}");
                
                if (_previousIndex.HasValue && _index.HasValue && _previousIndex.Value == _index.Value && _index.Value == value)
                {
                    if (_logIndex) Debug.Log($"{this} set {nameof(Index)} bailing out on identical values");
                    return;
                }

                _previousIndex = _index;
                _index = value;
                
                if (_logIndex) Debug.Log($"{this} set {nameof(Index)} _previousIndex {_previousIndex} _index {_index} starting tween");

                // TODO : determine where to play from if a tween between two different nodes was ongoing
                DOTween.To(()=> _transfer, x=> _transfer = x, 1f, _duration).SetEase(_ease);
                
            }
        }

        private readonly List<Node> _targets = new List<Node>();
        public void SetTargets(IEnumerable<Node> targets)
        {
            _targets.Clear();
            _targets.AddRange(targets);
        }
        
        protected virtual void Update()
        {
            Transform origin = transform;
            
            if (_previousIndex.HasValue && _index.HasValue)
            {
                Transform target1 = _targets[_previousIndex.Value].transform;
                Transform target2 = _targets[_index.Value].transform;
                
                Vector3 targetPosition = Vector3.Lerp(target1.position, target2.position, _transfer);
                Quaternion targetRotation = Quaternion.Slerp(target1.rotation, target2.rotation, _transfer);

                origin.position = Vector3.MoveTowards(origin.position, targetPosition, _minTransferVelocity * Time.deltaTime);
                origin.rotation = targetRotation;
            }
            else if (_index.HasValue)
            {
                Transform target = _targets[_index.Value].transform;
                
                origin.position = target.position;
                origin.rotation = target.rotation;
            }
        }
    }
}
