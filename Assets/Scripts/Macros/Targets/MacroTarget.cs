using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sonosthesia
{
    public class MacroTarget : MonoBehaviour
    {
        private readonly HashSet<IMacroProcessor> _processors = new HashSet<IMacroProcessor>();

        protected void RegisterProcessor(IMacroProcessor processor)
        {
            _processors.Add(processor);
        }
    
        protected virtual void Update()
        {
            foreach (IMacroProcessor processor in _processors)
            {
                processor.Update(Time.deltaTime);
            }
        }
        
        public virtual void SetFloat(float value)
        {
            _processors.SetFloat(value);
        }

        public virtual void SetColor(Color value)
        {
            _processors.SetColor(value);
        }
    
        public virtual void SetVector3(Vector3 value)
        {
            _processors.SetVector3(value);
        }
    
        public virtual void SetVector4(Vector4 value)
        {
            _processors.SetVector4(value);
        }
        
    }    
}


