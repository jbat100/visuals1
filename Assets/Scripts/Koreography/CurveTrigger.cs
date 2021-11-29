using System.Collections;
using System.Collections.Generic;
using SonicBloom.Koreo;
using UnityEngine;

public enum CurveAcumulationMode
{
    None,
    Sum,
    Max,
    Min
}

public class CurveTrigger : KoreoResponder
{

    
    [SerializeField] private AnimationCurve _animationCurve;

    [SerializeField] private CurveAcumulationMode _acumulationMode;

    [SerializeField] private float _fade;

    [SerializeField] private float _rest;

    
    public void Trigger(float scale)
    {
        
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
    }
    
    private HashSet<TriggerEntry> _entries = new HashSet<TriggerEntry>();

}
