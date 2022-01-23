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
        Random
    }
    
    public abstract class MIDIVFXDrivenSource<T> : MIDIVFXSource<T>
    {
        [SerializeField] private MIDIVFXDriver driver;

        [SerializeField] private float _offset;
        
        [SerializeField] private float _scale = 1f;

        [SerializeField] private Ease _ease = Ease.Linear;
        
        protected float SelectValueFromNote(MIDINote midiNote)
        {
            float raw = driver switch
            {
                MIDIVFXDriver.Channel => midiNote.Channel / 15f,
                MIDIVFXDriver.Note => midiNote.Note / 127f,
                MIDIVFXDriver.Velocity => midiNote.Velocity,
                MIDIVFXDriver.Random => Random.value,
                _ => 0f
            };

            float eased = DOVirtual.EasedValue(0f, 1f, raw, _ease);

            return (eased * _scale) + _offset;
        }
    }    
}


