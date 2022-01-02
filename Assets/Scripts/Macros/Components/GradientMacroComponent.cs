using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sonosthesia
{
    public class GradientMacroComponent : MacroComponent
    {
        [SerializeField] private Gradient _gradient;
    
        protected override void Apply(float value, MacroTarget target)
        {
            base.Apply(value, target);
            Color result = _gradient.Evaluate(value);
            target.SetColor(result);
        }
    }
}

