using UnityEngine;

namespace Sonosthesia
{
    public class MIDIVFXPathPositionSource : MIDIVFXDrivenSource<Vector3>
    {
        [SerializeField] private Path _path;

        [SerializeField] private bool _normlized;
        
        public override Vector3 MIDIToVFXAttribute(MIDINote note)
        {
            float value = SelectValueFromNote(note);
            return _path.Position(value, _normlized);
        }
    }    
}


