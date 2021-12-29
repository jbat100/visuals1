using System.Collections;
using System.Collections.Generic;
using Sonosthesia;
using UnityEngine;

public class LerpPath : Path
{
    [SerializeField] private SimplePath _startPath;
    [SerializeField] private SimplePath _endPath;
    [SerializeField, Range(0f, 1f)] private float _lerp;
    
    public override Vector3 Position(float distance)
    {
        Vector3 startPosition = _startPath.Position(distance);
        Vector3 endPosition = _endPath.Position(distance);
        return Vector3.Lerp(startPosition, endPosition, _lerp);
    }

    public override Quaternion Rotation(float distance)
    {
        Quaternion startRotation = _startPath.Rotation(distance);
        Quaternion endRotation = _endPath.Rotation(distance);
        return Quaternion.Slerp(startRotation, endRotation, _lerp);
    }
}
