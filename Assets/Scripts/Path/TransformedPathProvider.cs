using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;
using UnityTemplateProjects.Path;

public class TransformedPathProvider : MonoBehaviour, IPathProvider
{
    [SerializeField] private PathCreator _pathCreator;
    
    private VertexPath _vertexPath; 
    
    public VertexPath VertexPath
    {
        get
        {
            if (_vertexPath == null)
            {
                _vertexPath = new VertexPath (_pathCreator.EditorData.bezierPath, transform, _pathCreator.EditorData.vertexPathMaxAngleError, _pathCreator.EditorData.vertexPathMinVertexSpacing);
            }
            return _vertexPath;
        }
    }
}
