using UnityEngine;

namespace Sonosthesia
{
    public class MIDIVFXFloatLinearSource : MIDIVFXLinearSource<float>
    {
        protected override float Lerp(float start, float end, float value)
        {
            return Mathf.Lerp(start, end, value);
        }
    }
}

