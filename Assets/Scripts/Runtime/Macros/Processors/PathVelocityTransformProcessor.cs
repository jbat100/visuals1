using System;
using UnityEngine;

namespace Sonosthesia
{
    public interface IPathVelocityTransformProcessorParameters : IProcessorParameters, IOffsetParameters, IScaleParameters
    {
        Path Path { get; }
    }

    [Serializable]
    public class PathVelocityTransformProcessorParameters : OffsetScaleParameters, IPathVelocityTransformProcessorParameters
    {
        [SerializeField] private Path _path;
        public Path Path => _path;
    }
    
    public class PathVelocityTransformProcessor : TransformProcessor
    {
        private float _velocity;
        private float _distance;
        
        public PathVelocityTransformProcessor(Transform transform, IPathVelocityTransformProcessorParameters parameters) : base(transform, parameters)
        {
            
        }
        
        public override void SetFloat(float value)
        {
            _velocity = value;
        }

        public override void Update(float deltaTime)
        {
            IPathVelocityTransformProcessorParameters parameters = (IPathVelocityTransformProcessorParameters) _parameters;
            _distance += (_velocity * parameters.Scale + parameters.Offset) * Time.deltaTime;
            _transform.localPosition = parameters.Path.Position(_distance);
            _transform.localRotation = parameters.Path.Rotation(_distance);   
        }
    }
}


