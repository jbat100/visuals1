using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonosthesia
{
    public interface IMacroProcessor
    {
        void Setup();

        void Update(float deltaTime);
        
        void SetFloat(float value);
        void SetColor(Color value);
        void SetVector3(Vector3 value);
        void SetVector4(Vector4 value);
    }
    
    public static class MacroProcessorExtensions
    {
        public static void Broadcast(this IEnumerable<IMacroProcessor> processors, Action<IMacroProcessor> action)
        {
            foreach (IMacroProcessor processor in processors)
            {
                action(processor);
            }
        }
        
        public static void SetFloat(this IEnumerable<IMacroProcessor> processors, float value)
        {
            processors.Broadcast(processor => processor.SetFloat(value));
        }
        
        public static void SetColor(this IEnumerable<IMacroProcessor> processors, Color value)
        {
            processors.Broadcast(processor => processor.SetColor(value));
        }
        
        public static void SetVector3(this IEnumerable<IMacroProcessor> processors, Vector3 value)
        {
            processors.Broadcast(processor => processor.SetVector3(value));
        }
        
        public static void SetVector4(this IEnumerable<IMacroProcessor> processors, Vector4 value)
        {
            processors.Broadcast(processor => processor.SetVector4(value));
        }
    }
}
