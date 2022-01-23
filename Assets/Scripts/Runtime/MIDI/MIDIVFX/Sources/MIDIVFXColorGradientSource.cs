using UnityEngine;

namespace Sonosthesia
{
    public class MIDIVFXColorGradientSource : MIDIVFXSource<Color>
    {
        [SerializeField] private Gradient _gradient;

        public override Color MIDIToVFXAttribute(int channel, int note, float velocity)
        {
            float value = SelectValueFromNote(channel, note, velocity);
            return _gradient.Evaluate(value);
        }
    }    
}

