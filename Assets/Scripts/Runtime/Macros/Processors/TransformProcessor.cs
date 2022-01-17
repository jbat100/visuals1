using UnityEngine;

namespace Sonosthesia
{
    public class TransformProcessor : MacroProcessor
    {
        protected readonly Transform _transform;

        public TransformProcessor(Transform transform, IProcessorParameters parameters) : base(parameters)
        {
            _transform = transform;
        }
    }
}


