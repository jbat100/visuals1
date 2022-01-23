using UnityEngine;

namespace Sonosthesia
{

    public abstract class MIDIVFXSource<T> : MonoBehaviour, IMIDIVFXSource<T>
    {
        public abstract T MIDIToVFXAttribute(MIDINote note);
    }
    
}


