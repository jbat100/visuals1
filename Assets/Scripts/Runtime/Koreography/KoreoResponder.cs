using SonicBloom.Koreo;
using UnityEngine;

public class KoreoResponder : MonoBehaviour
{
    [EventID] [SerializeField] private string _eventID;
    
    protected virtual void Start()
    {
        Koreographer.Instance.RegisterForEventsWithTime(_eventID, OnEvent);
    }

    protected virtual void OnEvent(KoreographyEvent koreographyEvent, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
        
    }
}
