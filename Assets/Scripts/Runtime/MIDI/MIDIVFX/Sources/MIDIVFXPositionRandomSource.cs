using UnityEngine;

namespace Sonosthesia
{
    public class MIDIVFXPositionRandomSource : MIDIVFXSource<Vector3>
    {
        [SerializeField] float _range = 1f;
        
        public override Vector3 MIDIToVFXAttribute(MIDINote midiNote)
        {
            return _range * Random.insideUnitSphere;
        }
    }
}


