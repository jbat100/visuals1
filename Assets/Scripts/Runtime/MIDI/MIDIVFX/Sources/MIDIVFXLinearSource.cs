using UnityEngine;

namespace Sonosthesia
{
    public abstract class MIDIVFXLinearSource<T> : MIDIVFXSource<T>
    {
        [SerializeField] private T _start;

        [SerializeField] private T _end;
        
        public override T MIDIToVFXAttribute(int channel, int note, float velocity)
        {
            float value = SelectValueFromNote(channel, note, velocity);
            return Lerp(_start, _end, value);
        }

        protected abstract T Lerp(T start, T end, float value);
    }    
}


