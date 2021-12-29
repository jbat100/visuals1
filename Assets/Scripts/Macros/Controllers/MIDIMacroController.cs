using Minis;
using UnityEngine;
using UnityEngine.InputSystem;

public class MIDIMacroController : MacroController
{
    [SerializeField] private int _channel;
    [SerializeField] private int _number;
    
    protected override void Awake()
    {
        base.Awake();
        
        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            int GetChannel(MidiValueControl control) => ((Minis.MidiDevice) control.device).channel;

            midiDevice.onWillControlChange += (control, value) =>
            {
                int channel = GetChannel(control);
                MIDIControlChange(channel, control.controlNumber, value);
            };
        };
    }

    protected virtual void MIDIControlChange(int channel, int number, float value)
    {
        Debug.Log($"{this} {nameof(MIDIControlChange)} channel {channel} number {number} value {value}");
        
        if (channel == _channel && number == _number)
        {
            Broadcast(value);
        }
    }
}
