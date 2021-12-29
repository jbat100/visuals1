using System;
using UnityEngine;

public class TransformSpinMacroTarget : TransformMacroTarget
{
    [SerializeField] private Vector3 _axis = Vector3.up;
    
    [SerializeField] private float _factor;
    
    private Quaternion _reference;
    private float _angle;
    private float _rate;

    protected override void Awake()
    {
        base.Awake();
        _reference = Target.localRotation;
    }

    protected virtual void Update()
    {
        _angle += _rate * _factor * Time.deltaTime;
        Target.localRotation = Quaternion.AngleAxis(_angle, _axis) * _reference;
    }
    
    public override void SetFloat(float value)
    {
        _rate = value;
    }

    public override void SetVector3(Vector3 value)
    {
        _axis = value;
    }
}
