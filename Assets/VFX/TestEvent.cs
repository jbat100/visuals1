using UnityEngine;
using UnityEngine.VFX;

#if UNITY_EDITOR

using UnityEditor;

[CustomEditor(typeof(TestEvent))]
public class TestEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        TestEvent testEvent = (TestEvent)target;
        if(GUILayout.Button("Send"))
        {
            testEvent.SendEvent();
        }
    }
}

#endif

public class TestEvent : MonoBehaviour
{
    [SerializeField] private string _eventName;

    [SerializeField] private float _range;
    
    [SerializeField] private Color _eventColor;
    
    private VisualEffect _visualEffect;

    protected virtual void Awake()
    {
        _visualEffect = GetComponent<VisualEffect>();
    }

    public void SendEvent()
    {
        Debug.Log($"Send event : {_eventName}");

        Vector3 position = this.transform.position + Random.insideUnitSphere * _range;
        Color color = Random.ColorHSV(0, 1);
        
        VFXEventAttribute eventAttribute = _visualEffect.CreateVFXEventAttribute();
        
        eventAttribute.SetVector3("color", new Vector3(color.r, color.g, color.b));
        eventAttribute.SetVector3("position", position);
        
        _visualEffect.SendEvent(_eventName, eventAttribute);
    }
}
