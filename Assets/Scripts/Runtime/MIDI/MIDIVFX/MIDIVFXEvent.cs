using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.VFX;

namespace Sonosthesia
{
    public class MIDIVFXEvent : MIDINoteCallback
    {
        [SerializeField] private List<VisualEffect> _visualEffects;

        [SerializeField] private string _eventName;

        [SerializeField] private int _channel;

        [Header("Sources")] 
        
        [SerializeField] private MIDIVFXSource<Color> _colorSource;

        [SerializeField] private MIDIVFXSource<Vector3> _positionSource;

        [SerializeField] private MIDIVFXSource<Vector3> _scaleSource;

        [SerializeField] private MIDIVFXSource<float> _sizeSource;

        protected override void MIDINoteOn(MIDINote midiNote)
        {
            base.MIDINoteOn(midiNote);

            Debug.Log($"{nameof(MIDINoteOn)} {midiNote}");

            if (midiNote.Channel != _channel)
            {
                return;
            }

            foreach (VisualEffect visualEffect in _visualEffects)
            {
                VFXEventAttribute eventAttribute = visualEffect.CreateVFXEventAttribute();
                ConfigureAttribute(eventAttribute, midiNote);
                visualEffect.SendEvent(_eventName, eventAttribute);
            }
        }

        protected virtual void ConfigureAttribute(VFXEventAttribute eventAttribute, MIDINote midiNote)
        {
            StringBuilder descriptionBuilder = new StringBuilder($"{this} event ({midiNote}) attributes:");

            if (_colorSource)
            {
                Color color = _colorSource.MIDIToVFXAttribute(midiNote);
                eventAttribute.SetVector3("color", new Vector3(color.r, color.g, color.b));
                descriptionBuilder.Append($" color {color}");
            }

            if (_positionSource)
            {
                Vector3 position = _positionSource.MIDIToVFXAttribute(midiNote);
                eventAttribute.SetVector3("position", position);
                descriptionBuilder.Append($" position {position}");
            }

            if (_scaleSource)
            {
                Vector3 scale = _scaleSource.MIDIToVFXAttribute(midiNote);
                eventAttribute.SetVector3("scale", scale);
                descriptionBuilder.Append($" scale {scale}");
            }

            if (_sizeSource)
            {
                float size = _sizeSource.MIDIToVFXAttribute(midiNote);
                eventAttribute.SetFloat("size", size);
                descriptionBuilder.Append($" size {size}");
            }
        }
    }
}
