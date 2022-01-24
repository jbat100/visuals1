using System.Collections;
using System.Collections.Generic;
using Sonosthesia;
using UnityEngine;

public class LerpPath : Path
{
    [SerializeField] private SimplePath _startPath;
    [SerializeField] private SimplePath _endPath;
    [SerializeField, Range(0f, 1f)] private float _lerp;
    
    public override Vector3 Position(float distance, bool normalized)
    {
        Vector3 startPosition = _startPath.Position(distance, normalized);
        Vector3 endPosition = _endPath.Position(distance, normalized);
        return Vector3.Lerp(startPosition, endPosition, _lerp);
    }

    public override Quaternion Rotation(float distance, bool normalized)
    {
        Quaternion startRotation = _startPath.Rotation(distance, normalized);
        Quaternion endRotation = _endPath.Rotation(distance, normalized);
        return Quaternion.Slerp(startRotation, endRotation, _lerp);
    }
}
