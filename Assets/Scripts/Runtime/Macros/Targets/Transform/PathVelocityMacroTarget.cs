using Sonosthesia;
using UnityEngine;

public class PathVelocityMacroTarget : TransformMacroTarget
{
    [SerializeField] private PathVelocityTransformProcessorParameters _parameters;
    
    protected override TransformProcessor CreateTransformProcessor(Transform target)
    {
        return new PathVelocityTransformProcessor(target, _parameters);
    }
}
