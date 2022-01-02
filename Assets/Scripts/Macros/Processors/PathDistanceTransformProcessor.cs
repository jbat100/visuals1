using System;
using UnityEngine;

namespace Sonosthesia
{
    public interface IPathDistanceTransformProcessorParameters : IProcessorParameters, IOffsetParameters, IScaleParameters
    {
        Path Path { get; }
    }

    [Serializable]
    public class PathDistanceTransformProcessorParameters : OffsetScaleParameters, IPathDistanceTransformProcessorParameters
    {
        [SerializeField] private Path _path;
        public Path Path => _path;
    }
    
    public class PathDistanceTransformProcessor : TransformProcessor
    {
        public PathDistanceTransformProcessor(Transform transform, PathDistanceTransformProcessorParameters parameters) : base(transform, parameters)
        {
            
        }
        
        public override void SetFloat(float value)
        {
            IPathDistanceTransformProcessorParameters parameters = (IPathDistanceTransformProcessorParameters) _parameters;
            float distance = (value * parameters.Scale) + parameters.Offset;
            _transform.localPosition = parameters.Path.Position(distance);
            _transform.localRotation = parameters.Path.Rotation(distance);   
        }
    }

}

