using UnityEngine;

namespace Sonosthesia
{
    public class MIDIVFXColorLinearSource : MIDIVFXLinearSource<Color>, IMIDIVFXColorSource
    {
        protected override Color Lerp(Color start, Color end, float value)
        {
            return Color.Lerp(start, end, value);
        }
    }
}


