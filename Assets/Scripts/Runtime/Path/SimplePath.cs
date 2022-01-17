using PathCreation;
using Sonosthesia;
using UnityEngine;
using UnityTemplateProjects.Path;

public class SimplePath : Path, IPathProvider
{
    [SerializeField] private PathCreator _pathCreator;
    [SerializeField] private EndOfPathInstruction _endOfPathInstruction;
    
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
    
    public override Vector3 Position(float distance) => VertexPath.GetPointAtDistance(distance, _endOfPathInstruction);

    public override Quaternion Rotation(float distance) => VertexPath.GetRotationAtDistance(distance, _endOfPathInstruction);
}
