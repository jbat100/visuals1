using UnityEngine;

namespace Sonosthesia
{
    public class SpinTransformTarget : TransformMacroTarget
    {
        [SerializeField] private SpinProcessorParameters _parameters;

        protected override TransformProcessor CreateTransformProcessor(Transform target)
        {
            return new SpinTransformProcessor(target, _parameters);
        }
    }
}


