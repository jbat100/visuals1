using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class TransformedPathLerper : MonoBehaviour
{
    [SerializeField] private TransformedPathProvider _startProvider;
    [SerializeField] private TransformedPathProvider _endProvider;
    [SerializeField, Range(0f, 1f)] private float _lerp;
    [SerializeField] private EndOfPathInstruction _endOfPathInstruction;
    [SerializeField] private float _speed = 5;

    private float _distanceTravelled;
    
    void Update()
    {
        _distanceTravelled += _speed * Time.deltaTime;

        Vector3 startPosition = _startProvider.VertexPath.GetPointAtDistance(_distanceTravelled, _endOfPathInstruction);
        Vector3 endPosition = _endProvider.VertexPath.GetPointAtDistance(_distanceTravelled, _endOfPathInstruction);
        transform.position = Vector3.Lerp(startPosition, endPosition, _lerp);
        
        Quaternion startRotation = _startProvider.VertexPath.GetRotationAtDistance(_distanceTravelled, _endOfPathInstruction);
        Quaternion endRotation = _startProvider.VertexPath.GetRotationAtDistance(_distanceTravelled, _endOfPathInstruction);
        transform.rotation = Quaternion.Slerp(startRotation, endRotation, _lerp);
    }
}
 