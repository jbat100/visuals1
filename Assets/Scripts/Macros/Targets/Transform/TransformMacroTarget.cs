using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonosthesia
{
    public class TransformMacroTarget : MacroTarget
    {
        [SerializeField] private List<Transform> _targets;

        protected virtual void Awake()
        {
            foreach (Transform target in _targets)
            {
                TransformProcessor processor = CreateTransformProcessor(target);
                processor.Setup();
                RegisterProcessor(processor);
            }
        }

        protected virtual TransformProcessor CreateTransformProcessor(Transform target)
        {
            throw new NotImplementedException();
        }
    }
}


