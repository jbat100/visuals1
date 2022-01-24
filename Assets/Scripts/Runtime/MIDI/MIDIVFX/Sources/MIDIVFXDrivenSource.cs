using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Sonosthesia
{
    public enum MIDIVFXDriver
    {
        None,
        Channel,
        Note,
        Velocity,
        Random,
        Time
    }
    
    public abstract class MIDIVFXDrivenSource<T> : MIDIVFXSource<T>
    {
        [SerializeField] private MIDIVFXDriver _driver;

        [SerializeField] private float _offset;
        
        [SerializeField] private float _scale = 1f;

        [SerializeField] private Ease _ease = Ease.Linear;

        [SerializeField] private float _warp = 1f;
        
        protected float SelectValueFromNote(MIDINote midiNote)
        {
            if (_driver == MIDIVFXDriver.Time)
            {
                float time = (Time.time * _scale) + _offset;
                return time - Mathf.Floor(time);
            }
            
            float raw = _driver switch
            {
                MIDIVFXDriver.Channel => midiNote.Channel / 15f,
                MIDIVFXDriver.Note => midiNote.Note / 127f,
                MIDIVFXDriver.Velocity => midiNote.Velocity,
                MIDIVFXDriver.Random => Random.value,
                MIDIVFXDriver.Time => (Time.time * _warp) - (Mathf.Floor(Time.time * _warp)),
                _ => 0f
            };

            float eased = DOVirtual.EasedValue(0f, 1f, raw, _ease);

            return (eased * _scale) + _offset;
        }
    }    
}


