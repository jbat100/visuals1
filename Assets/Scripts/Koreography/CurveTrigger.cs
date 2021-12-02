using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SonicBloom.Koreo;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(CurveTrigger))]
public class CurveTriggerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        CurveTrigger curveTrigger = (CurveTrigger)target;
        if(GUILayout.Button("Trigger"))
        {
            curveTrigger.Trigger(1f);
        }
    }
}
#endif

public enum AccumulationMode
{
    None,
    Sum,
    Max,
    Min
}

public class CurveTrigger : KoreoResponder
{
    [SerializeField] private AnimationCurve _animationCurve;

    [SerializeField] private AccumulationMode _acumulationMode = AccumulationMode.Max;

    [SerializeField] private float _fade = 1f;

    [SerializeField] private float _rest;

    protected override void OnEvent(KoreographyEvent koreographyEvent, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
        if (koreographyEvent.HasIntPayload())
        {
            float curveValue = koreographyEvent.GetIntValue();
            Trigger(1f);
        }
    }
    
    public void Trigger(float scale)
    {
        _entries.Add(new TriggerEntry(Time.time, scale, _fade, _animationCurve));
    }

    private float? _curveValue;
    public float CurveValue
    {
        get
        {
            if (_curveValue.HasValue)
            {
                return _curveValue.Value;
            }

            return (_curveValue = _entries.Aggregate(_rest, (current, entry) => entry.Accumulate(Time.time, _acumulationMode, current))).Value;
        }
    }

    protected virtual void Update()
    {
        _curveValue = null;
        
        _entries.ExceptWith(_entries.Where(entry => entry.Ended(Time.time)));
    }

    private class TriggerEntry
    {
        private float _startTime;
        private float _scale;
        private float _fade;
        private AnimationCurve _animationCurve;
        private float _fadeTime;
        private float _endTime;
        
        public TriggerEntry(float startTime, float scale, float fade, AnimationCurve animationCurve)
        {
            _startTime = startTime;
            _scale = scale;
            _fade = fade;
            _animationCurve = animationCurve;
            _fadeTime = _startTime + animationCurve.keys[animationCurve.keys.Length - 1].time;
            _endTime = _fadeTime + animationCurve.keys[animationCurve.keys.Length - 1].value * _fade;
        }

        public bool Ended(float time) => time > _endTime;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="time">Absolute unity time</param>
        /// <returns></returns>
        public float GetValue(float time)
        {
            if (time > _endTime)
            {
                return 0f;
            }
            
            float result = _animationCurve.Evaluate(time - _startTime);

            if (time > _fadeTime)
            {
                return result * ((_fadeTime - time) / (_endTime - _fadeTime));
            }

            return result;
        }

        public float Accumulate(float time, AccumulationMode accumulationMode, float current)
        {
            float value = GetValue(time);
            return accumulationMode switch
            {
                AccumulationMode.Sum => current + value,
                AccumulationMode.Max => Mathf.Max(current, value),
                AccumulationMode.Min => Mathf.Min(current, value),
                _ => throw new NotImplementedException()
            };
        }
    }
    
    private readonly HashSet<TriggerEntry> _entries = new HashSet<TriggerEntry>();

}
