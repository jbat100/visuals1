using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class VFXMacroTarget : MacroTarget
{
    [SerializeField] private VisualEffect _visualEffect;

    [SerializeField] private string _nameID;
    
    public override void SetFloat(float value)
    {
        _visualEffect.SetFloat(_nameID, value);
    }

    public override void SetColor(Color value)
    {
        _visualEffect.SetVector4(_nameID, value);
    }
    
    public override void SetVector3(Vector3 value)
    {
        _visualEffect.SetVector3(_nameID, value);
    }
    
    public override void SetVector4(Vector4 value)
    {
        _visualEffect.SetVector4(_nameID, value);
    }
}
