using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonosthesia
{
    public class AnimationCurveMacroComponent : MacroComponent
    {
        [SerializeField] private AnimationCurve _animationCurve;
    
        protected override void Apply(float value, MacroTarget target)
        {
            base.Apply(value, target);
            float result = _animationCurve.Evaluate(value);
            target.SetFloat(result);
        }
    }

}

