using Sonosthesia;
using UnityEngine;

public class PathVelocityMacroTarget : TransformMacroTarget
{
    [SerializeField] private Path _path;
    [SerializeField] private float _factor = 1f;
    [SerializeField] private float _offset = 0f;
    [SerializeField] private bool _local;

    private float _velocity;
    private float _distance;
    
    public override void SetFloat(float value)
    {
        _velocity = value;
    }

    protected virtual void Update()
    {
        _distance += (_velocity * _factor + _offset) * Time.deltaTime;
        if (_local)
        {
            Target.localPosition = _path.Position(_distance);
            Target.localRotation = _path.Rotation(_distance);   
        }
        else
        {
            Target.position = _path.Position(_distance);
            Target.rotation = _path.Rotation(_distance);   
        }
    }
}
