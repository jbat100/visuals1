using UnityEngine;

[RequireComponent(typeof(CurveTrigger))]
public class CurveTriggerDisplacement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    
    [SerializeField] private Vector3 _direction;

    [SerializeField] private float _scale = 1f;

    private CurveTrigger _curveTrigger;
    private Vector3 _reference;
    
    protected virtual void Awake()
    {
        if (!_target)
        {
            _target = transform;
        }

        _reference = _target.localPosition;
        
        _curveTrigger = GetComponent<CurveTrigger>();
    }

    protected virtual void Update()
    {
        _target.localPosition = _reference + (_curveTrigger.CurveValue * _scale * _direction);
    }
}
