using UnityEngine;

namespace Sonosthesia
{
    public abstract class MIDIVFXLinearSource<T> : MIDIVFXDrivenSource<T>
    {
        [SerializeField] private T _start;

        [SerializeField] private T _end;
        
        public override T MIDIToVFXAttribute(MIDINote midiNote)
        {
            float value = SelectValueFromNote(midiNote);
            return Lerp(_start, _end, value);
        }

        protected abstract T Lerp(T start, T end, float value);
    }    
}


