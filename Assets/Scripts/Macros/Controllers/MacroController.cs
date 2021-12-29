using System.Collections.Generic;
using UnityEngine;

public class MacroController : MonoBehaviour
{
    private readonly List<MacroComponent> _components = new List<MacroComponent>();

    [SerializeField] private float _lerp;

    private float? current;
    private float? target;
    
    protected virtual void Awake()
    {
        _components.AddRange(GetComponentsInChildren<MacroComponent>());
    }

    protected void Broadcast(float value)
    {
        if (_lerp == 0f)
        {
            Debug.Log($"{this} {nameof(Broadcast)} unlerped {value} to {_components.Count} component(s)");
            foreach (MacroComponent component in _components)
            {
                component.Value = value;
            }
        }
        else
        {
            target = value;
        }
    }

    protected virtual void Update()
    {
        if (target.HasValue)
        {
            current = current.HasValue ? Mathf.Lerp(current.Value, target.Value, _lerp) : target.Value;
            Debug.Log($"{this} {nameof(Broadcast)} lerped {current.Value} to {_components.Count} component(s)");
            foreach (MacroComponent component in _components)
            {
                component.Value = current.Value;
            }
        }
    }
}
