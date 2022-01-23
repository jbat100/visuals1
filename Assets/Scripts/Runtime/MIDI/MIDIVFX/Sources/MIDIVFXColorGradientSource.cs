using UnityEngine;

namespace Sonosthesia
{
    public class MIDIVFXColorGradientSource : MIDIVFXDrivenSource<Color>
    {
        [SerializeField] private Gradient _gradient;

        public override Color MIDIToVFXAttribute(MIDINote midiNote)
        {
            float value = SelectValueFromNote(midiNote);
            return _gradient.Evaluate(value);
        }
    }    
}

