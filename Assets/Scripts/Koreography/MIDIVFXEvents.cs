using SonicBloom.Koreo;
using SonicBloom.Koreo.Demos;
using SonicBloom.MIDI.Objects;
using UnityEngine;
using UnityEngine.VFX;

public class MIDIVFXEvents : KoreoResponder
{
    [SerializeField] private string _eventName;

    [SerializeField] private float _distanceRange;
    
    [SerializeField] private Gradient _gradient;

    [SerializeField] private Vector2 _scaleRange;
    
    private VisualEffect _visualEffect;
    
    protected virtual void Awake()
    {
        _visualEffect = GetComponent<VisualEffect>();
    }
    
    protected virtual void OnEvent(KoreographyEvent koreographyEvent, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
        if (koreographyEvent.HasMIDIPayload())
        {
            int note = 0;
            int velocity = 0;
            koreographyEvent.GetMIDIValues(ref note, ref velocity);

            Color color = _gradient.Evaluate(note / 127);
            float scale = _scaleRange.y * velocity / 127;

        }
        
        
    }
    
    public void SendEvent(Color color, float scale)
    {
        Debug.Log($"Send event : {_eventName}");

        Vector3 position = this.transform.position + Random.insideUnitSphere * _distanceRange;
        
        VFXEventAttribute eventAttribute = _visualEffect.CreateVFXEventAttribute();
        
        eventAttribute.SetVector3("color", new Vector3(color.r, color.g, color.b));
        eventAttribute.SetVector3("position", position);
        eventAttribute.SetVector3("scale", scale * Vector3.one);
        
        _visualEffect.SendEvent(_eventName, eventAttribute);
    }
    
}
