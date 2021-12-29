using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class MacroComponent : MonoBehaviour
{
    [SerializeField] private MacroTarget _target;
    
    private bool _dirty;
    private float _value;
    public float Value
    {
        get => _value;
        set
        {
            Debug.Log($"{this} set {nameof(Value)} {value}");
            _value = value;
            _dirty = true;
        }
    }

    protected virtual void Update()
    {
        if (_dirty)
        {
            Apply(_value, _target);
            _dirty = false;
        }
    }

    protected virtual void Apply(float value, MacroTarget target)
    {
        
    }
}
