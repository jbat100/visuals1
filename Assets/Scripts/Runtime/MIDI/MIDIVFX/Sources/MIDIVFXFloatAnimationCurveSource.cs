using UnityEngine;

namespace Sonosthesia
{
    public class MIDIVFXFloatAnimationCurveSource : MIDIVFXDrivenSource<float>
    {
        [SerializeField] private AnimationCurve _animationCurve;
        
        public override float MIDIToVFXAttribute(MIDINote midiNote)
        {
            float value = SelectValueFromNote(midiNote);
            return _animationCurve.Evaluate(value);
        }
    }
}


