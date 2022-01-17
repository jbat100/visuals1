using UnityEngine;

namespace Sonosthesia
{
    public class MacroProcessor : IMacroProcessor
    {
        protected readonly IProcessorParameters _parameters;
        
        public MacroProcessor(IProcessorParameters parameters)
        {
            _parameters = parameters;
        }

        public virtual void Setup()
        {

        }

        public virtual void Update(float deltaTime)
        {

        }

        public virtual void SetFloat(float value)
        {

        }

        public virtual void SetColor(Color value)
        {

        }

        public virtual void SetVector3(Vector3 value)
        {

        }

        public virtual void SetVector4(Vector4 value)
        {

        }
    }


}