using UnityEngine;

namespace Sonosthesia
{
    public interface IMIDIVFXSource<out T>
    {
        T MIDIToVFXAttribute(MIDINote note);
    }
    
    public interface IMIDIVFXColorSource : IMIDIVFXSource<Color> { }
    
    public interface IMIDIVFXPositionSource : IMIDIVFXSource<Vector3> { }
    
    public interface IMIDIVFXRotationSource : IMIDIVFXSource<Quaternion> { }
    
    public interface IMIDIVFXScaleSource : IMIDIVFXSource<Vector3> { }
    
    public interface IMIDIVFXSizeSource : IMIDIVFXSource<float> { }
}

