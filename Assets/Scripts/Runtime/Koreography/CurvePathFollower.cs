using PathCreation;
using SonicBloom.Koreo;
using Sonosthesia;
using UnityEngine;

public class CurvePathFollower : KoreoResponder
{
    [SerializeField] private Path _path;
    [SerializeField] private float _speed = 5;
    [SerializeField] private bool _normalized;

    private float _factor;
    
    private float _distanceTravelled;

    void Update()
    {
        Debug.Log($"{this} {nameof(Update)} with {nameof(_factor)} {_factor}");
        
        _distanceTravelled += _speed * _factor * Time.deltaTime;
        transform.position = _path.Position(_distanceTravelled, _normalized);
        transform.rotation = _path.Rotation(_distanceTravelled, _normalized);
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
