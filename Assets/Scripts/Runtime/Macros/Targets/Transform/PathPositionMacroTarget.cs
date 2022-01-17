using UnityEngine;

namespace Sonosthesia
{
    public class PathPositionMacroTarget : TransformMacroTarget
    {
        [SerializeField] private PathDistanceTransformProcessorParameters _parameters;

        protected override TransformProcessor CreateTransformProcessor(Transform target)
        {
            return new PathDistanceTransformProcessor(target, _parameters);
        }
    }
}
