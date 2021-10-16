using System.Collections;
using System.Collections.Generic;
using PathCreation;
using UnityEngine;

public class TransformedPathFollower : MonoBehaviour
{
    [SerializeField] private TransformedPathProvider _provider;
    [SerializeField] private EndOfPathInstruction _endOfPathInstruction;
    [SerializeField] private float _speed = 5;

    private float _distanceTravelled;

    void Update()
    {
        _distanceTravelled += _speed * Time.deltaTime;
        transform.position = _provider.VertexPath.GetPointAtDistance(_distanceTravelled, _endOfPathInstruction);
        transform.rotation = _provider.VertexPath.GetRotationAtDistance(_distanceTravelled, _endOfPathInstruction);
    }
}
