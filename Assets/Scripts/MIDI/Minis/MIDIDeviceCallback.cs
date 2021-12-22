using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MIDIDeviceCallback : MonoBehaviour
{
    void Start()
    {
        InputSystem.onDeviceChange += (device, change) =>
        {
            var midiDevice = device as Minis.MidiDevice;
            if (midiDevice == null) return;

            Debug.Log(string.Format("{0} ({1}) {2}",
                device.description.product, midiDevice.channel, change));
        };
    }
}
