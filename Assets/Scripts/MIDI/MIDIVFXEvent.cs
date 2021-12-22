using UnityEngine;
using UnityEngine.VFX;

public class MIDIVFXEvent : MIDINoteCallback
{
    [SerializeField] private string _eventName;

    [SerializeField] private float _distanceRange;
    
    [SerializeField] private Gradient _gradient;

    [SerializeField] private Vector2 _scaleRange;

    [SerializeField] private int _channel;
    
    private VisualEffect _visualEffect;
    
    protected override void Awake()
    {
        _visualEffect = GetComponent<VisualEffect>();
        base.Awake();
    }

    public void SendEvent(Color color, float scale)
    {
        Debug.Log($"Send event : {_eventName} color {color} scale {scale}");

        Vector3 position = this.transform.position + Random.insideUnitSphere * _distanceRange;
        
        VFXEventAttribute eventAttribute = _visualEffect.CreateVFXEventAttribute();
        
        eventAttribute.SetVector3("color", new Vector3(color.r, color.g, color.b));
        eventAttribute.SetVector3("position", position);
        eventAttribute.SetVector3("scale", scale * Vector3.one);
        
        _visualEffect.SendEvent(_eventName, eventAttribute);
    }
    
    protected override void MIDINoteOn(int channel, int note, float velocity)
    {
        base.MIDINoteOn(channel, note, velocity);
        
        Debug.Log($"MIDI channel {channel} note {note} velocity {velocity}");
        
        if (channel != _channel)
        {
            return;
        }
        
        Color color = _gradient.Evaluate(note / 127f);
        float scale = _scaleRange.y * velocity;
        
        SendEvent(color, scale);
    }
   
}
