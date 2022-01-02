using UnityEngine;

namespace Sonosthesia
{
    public class TransformRotationTarget : TransformMacroTarget
    {
        [SerializeField] private RotationProcessorParameters _parameters;

        protected override TransformProcessor CreateTransformProcessor(Transform target)
        {
            return new RotationTransformProcessor(target, _parameters);
        }
    }
}

