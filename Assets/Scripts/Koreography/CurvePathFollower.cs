using PathCreation;
using SonicBloom.Koreo;
using UnityEngine;

public class CurvePathFollower : KoreoResponder
{
    [SerializeField] private TransformedPathProvider _provider;
    [SerializeField] private EndOfPathInstruction _endOfPathInstruction;
    [SerializeField] private float _speed = 5;

    private float _factor;
    
    private float _distanceTravelled;

    void Update()
    {
        Debug.Log($"{this} {nameof(Update)} with {nameof(_factor)} {_factor}");
        
        _distanceTravelled += _speed * _factor * Time.deltaTime;
        transform.position = _provider.VertexPath.GetPointAtDistance(_distanceTravelled, _endOfPathInstruction);
        transform.rotation = _provider.VertexPath.GetRotationAtDistance(_distanceTravelled, _endOfPathInstruction);
    }
    
    protected override void OnEvent(KoreographyEvent koreographyEvent, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
        base.OnEvent(koreographyEvent, sampleTime, sampleDelta, deltaSlice);
        
        if (koreographyEvent.HasCurvePayload())
        {
            _factor = koreographyEvent.GetValueOfCurveAtTime(sampleTime);
        }
    }
    
}
