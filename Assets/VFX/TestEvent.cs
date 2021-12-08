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
    
    private VisualEffect _visualEffect;

    protected virtual void Awake()
    {
        _visualEffect = GetComponent<VisualEffect>();
    }

    public void SendEvent()
    {
        Debug.Log($"Send event : {_eventName}");
        _visualEffect.SendEvent(_eventName);
    }
}
