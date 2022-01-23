using UnityEngine;

namespace Sonosthesia
{
    public class MIDIVFXVector3LinearSource : MIDIVFXLinearSource<Vector3>
    {
        protected override Vector3 Lerp(Vector3 start, Vector3 end, float value)
        {
            return Vector3.Lerp(start, end, value);
        }
    }
}