using UnityEngine;
using UnityEngine.VFX;

public class LinearColorMacroComponent : LinearMacroComponent
{
    [SerializeField] [ColorUsage(true, true)] private Color _start;
    [SerializeField] [ColorUsage(true, true)] private Color _end;

    protected override void Apply(float value, MacroTarget target)
    {
        base.Apply(value, target);
        Color result = Color.Lerp(_start, _end, value);
        target.SetColor(result);
    }
}
