using Sonosthesia;
using UnityEngine;

public class PathPositionMacroTarget : TransformMacroTarget
{
    [SerializeField] private Path _path;
    [SerializeField] private float _factor = 1f;
    [SerializeField] private float _offset = 0f;
    [SerializeField] private bool _local;
    
    public override void SetFloat(float value)
    {
        float distance = (value * _factor) + _offset;
        if (_local)
        {
            Target.localPosition = _path.Position(distance);
            Target.localRotation = _path.Rotation(distance);   
        }
        else
        {
            Target.position = _path.Position(distance);
            Target.rotation = _path.Rotation(distance);   
        }
    }
}
