using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonosthesia
{
    
    public class TransformNodeMacroTarget : NodeMacroTarget
    {
        protected class TransformNodeProcessor : NodeProcessor
        {
            private TransformProcessor _transformProcessor;

            public TransformNodeProcessor(Node node, IProcessorParameters parameters) : base(node, parameters)
            {
                
            }

            public virtual TransformProcessor CreateTransformProcessor(Transform transform, IProcessorParameters parameters)
            {
                throw new NotImplementedException();
            }

            public override void Setup()
            {
                base.Setup();
                _transformProcessor = CreateTransformProcessor(_node.transform, _parameters);
                _transformProcessor.Setup();
            }

            public override void Update(float deltaTime)
            {
                base.Update(deltaTime);
                _transformProcessor.Update(deltaTime);
            }

            public override void SetFloat(float value)
            {
                _transformProcessor.SetFloat(value);
            }
        } 
    }
    
}


