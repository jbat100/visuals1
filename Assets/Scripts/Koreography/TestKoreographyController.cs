using System.Collections;
using System.Collections.Generic;
using SonicBloom.Koreo;
using UnityEngine;

public class TestKoreographyController : MonoBehaviour
{
    [EventID] [SerializeField] private string _eventID;

    [SerializeField] private List<Renderer> _renderers;

    [SerializeField] private List<Transform> _scalers;

    protected void Awake()
    {
        Koreographer.Instance.RegisterForEventsWithTime(_eventID, Callback);
    }
    
    protected void OnDestroy()
    {
        if (Koreographer.Instance != null)
        {
            Koreographer.Instance.UnregisterForAllEvents(this);
        }
    }

    private void Callback(KoreographyEvent koreographyEvent, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
        Debug.Log($"{this} got {koreographyEvent} with payload {koreographyEvent.Payload} {nameof(sampleTime)} {sampleTime} {nameof(sampleDelta)} {sampleDelta}");

        if (koreographyEvent.HasGradientPayload())
        {
            Color color = koreographyEvent.GetColorOfGradientAtTime(sampleTime);
            foreach (Renderer r in _renderers)
            {
                r.material.color = color;
            }
        }

        if (koreographyEvent.HasCurvePayload())
        {
            float value = koreographyEvent.GetValueOfCurveAtTime(sampleTime);
            foreach (Transform scaler in _scalers)
            {
                scaler.localScale = Vector3.one * value;
            }
        }
        
        
    }
}
