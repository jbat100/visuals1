using System;
using UnityEngine;

namespace Sonosthesia
{
    public interface ISpinProcessorParameters : IProcessorParameters, IOffsetParameters, IScaleParameters
    {
        Vector3 Axis { get; }
    }

    [Serializable]
    public class SpinProcessorParameters : OffsetScaleParameters, ISpinProcessorParameters
    {
        [SerializeField] private Vector3 _axis = Vector3.up;
        public Vector3 Axis => _axis;
    }
    
    public class SpinTransformProcessor : TransformProcessor
    {
        private Quaternion _reference;
        private float _angle;
        private float _rate;
        
        public SpinTransformProcessor(Transform transform, ISpinProcessorParameters parameters) : base(transform, parameters)
        {
            
        }

        public override void Setup()
        {
            base.Setup();
            _reference = _transform.localRotation;
        }
        
        public override void SetFloat(float value)
        {
            _rate = value;
        }

        public override void Update(float deltaTime)
        {
            base.Update(deltaTime);
            ISpinProcessorParameters parameters = (ISpinProcessorParameters) _parameters;
            _angle += (_rate * parameters.Scale + parameters.Offset) * Time.deltaTime;
            _transform.localRotation = Quaternion.AngleAxis(_angle, parameters.Axis) * _reference;
        }
    }    
}

