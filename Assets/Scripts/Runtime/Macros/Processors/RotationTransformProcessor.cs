using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonosthesia
{
    public interface IRotationProcessorParameters : IProcessorParameters, IOffsetParameters, IScaleParameters
    {
        Vector3 Axis { get; }
    }

    [Serializable]
    public class RotationProcessorParameters : OffsetScaleParameters, IRotationProcessorParameters
    {
        [SerializeField] private Vector3 _axis = Vector3.up;
        public Vector3 Axis => _axis;
    }
    
    public class RotationTransformProcessor : TransformProcessor
    {
        private Quaternion _reference;
        
        public RotationTransformProcessor(Transform transform, IRotationProcessorParameters parameters) : base(transform, parameters)
        {
            
        }

        public override void Setup()
        {
            base.Setup();
            _reference = _transform.localRotation;
        }
        
        public override void SetFloat(float value)
        {
            IRotationProcessorParameters parameters = (IRotationProcessorParameters) _parameters;
            _transform.localRotation = Quaternion.AngleAxis(value * parameters.Scale + parameters.Offset, parameters.Axis) * _reference;
        }
    }    
}
