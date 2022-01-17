using UnityEngine;

namespace Sonosthesia
{
    public class SpinTransformNodeTarget : TransformNodeMacroTarget
    {
        [SerializeField] private SpinProcessorParameters _parameters;
        
        protected class SpinTransformNodeProcessor : TransformNodeProcessor
        {
            public SpinTransformNodeProcessor(Node node, IProcessorParameters parameters) : base(node, parameters) { }

            public override TransformProcessor CreateTransformProcessor(Transform transform, IProcessorParameters parameters)
            {
                return new SpinTransformProcessor(transform, (ISpinProcessorParameters)parameters);
            }
        } 

        protected override NodeProcessor CreateProcessor(Node node)
        {
            return new SpinTransformNodeProcessor(node, _parameters);
        }

    }

}

