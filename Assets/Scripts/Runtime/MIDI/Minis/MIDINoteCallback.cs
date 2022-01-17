using System.Collections;
using System.Collections.Generic;
using Minis;
using UnityEngine;
using UnityEngine.InputSystem;

public class MIDINoteCallback : MonoBehaviour
{
    protected virtual void Awake()
    {
        InputSystem.onDeviceChange += (device, change) =>
        {
            if (change != InputDeviceChange.Added) return;

            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            int GetChannel(MidiNoteControl note) => ((Minis.MidiDevice) note.device).channel;
            
            midiDevice.onWillNoteOn += (note, velocity) => {
                // Note that you can't use note.velocity because the state
                // hasn't been updated yet (as this is "will" event). The note
                // object is only useful to specify the target note (note
                // number, channel number, device name, etc.) Use the velocity
                // argument as an input note velocity.

                int channel = GetChannel(note);
                
                Debug.Log(string.Format(
                    "Note On #{0} ({1}) vel:{2:0.00} ch:{3} dev:'{4}'",
                    note.noteNumber,
                    note.shortDisplayName,
                    velocity,
                    (note.device as Minis.MidiDevice)?.channel,
                    note.device.description.product
                ));
                MIDINoteOn(channel, note.noteNumber, velocity);
            };

            midiDevice.onWillNoteOff += (note) => {
                
                int channel = GetChannel(note);
                
                Debug.Log(string.Format(
                    "Note Off #{0} ({1}) ch:{2} dev:'{3}'",
                    note.noteNumber,
                    note.shortDisplayName,
                    (note.device as Minis.MidiDevice)?.channel,
                    note.device.description.product
                ));
                
                MIDINoteOff(channel, note.noteNumber, note.velocity);
            };
        };
    }

    protected virtual void MIDINoteOn(int channel, int note, float velocity)
    {
        
    }

    protected virtual void MIDINoteOff(int channel, int note, float velocity)
    {
        
    }
}
