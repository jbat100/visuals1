using UnityEngine;

public class TransformRotationMacroTarget : TransformMacroTarget
{
    [SerializeField] private Vector3 _axis = Vector3.up;

    [SerializeField] private float _factor;
    
    private Quaternion _reference;

    protected virtual void Awake()
    {
        base.Awake();
        _reference = Target.localRotation;
    }
    
    public override void SetFloat(float value)
    {
        Target.localRotation = Quaternion.AngleAxis(value * _factor, _axis) * _reference;
    }
    
    public override void SetVector3(Vector3 value)
    {
        _axis = value;
    }
}
