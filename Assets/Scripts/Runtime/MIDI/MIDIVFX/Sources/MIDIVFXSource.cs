using DG.Tweening;
using UnityEngine;

namespace Sonosthesia
{
    public enum MIDIVFXSelector
    {
        None,
        Channel,
        Note,
        Velocity,
        Control
    }

    public abstract class MIDIVFXSource<T> : MonoBehaviour, IMIDIVFXSource<T>
    {
        [SerializeField] private MIDIVFXSelector _selector;

        [SerializeField] private float _offset;
        
        [SerializeField] private float _scale;

        [SerializeField] private Ease _ease = Ease.Linear;
        
        protected float SelectValueFromNote(int channel, int note, float velocity)
        {
            float raw = _selector switch
            {
                MIDIVFXSelector.Channel => channel / 15f,
                MIDIVFXSelector.Note => note / 127f,
                MIDIVFXSelector.Velocity => velocity,
                _ => 0f
            };

            float eased = DOVirtual.EasedValue(0f, 1f, raw, _ease);

            return (eased * _scale) + _offset;
        }

        public abstract T MIDIToVFXAttribute(int channel, int note, float velocity);
    }
    
}


