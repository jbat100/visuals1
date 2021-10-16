// OSC Jack - Open Sound Control plugin for Unity
// https://github.com/keijiro/OscJack

using UnityEngine;
using UnityEditor;
using DataType = OscJack.OscEventReceiver.DataType;


[CanEditMultipleObjects, CustomEditor(typeof(ConfigurableEventReceiver))]
class ConfigurableEventReceiverEditor : Editor
{
    SerializedProperty _configuration;
    SerializedProperty _oscAddress;
    SerializedProperty _dataType;

    SerializedProperty _event;
    SerializedProperty _intEvent;
    SerializedProperty _floatEvent;
    SerializedProperty _stringEvent;
    SerializedProperty _vector2Event;
    SerializedProperty _vector3Event;
    SerializedProperty _vector4Event;
    SerializedProperty _vector2IntEvent;
    SerializedProperty _vector3IntEvent;

    static class Labels
    {
        public static readonly GUIContent Configuration = new GUIContent("Configuration");
        public static readonly GUIContent OSCAddress = new GUIContent("OSC Address");
    }

    void OnEnable()
    {
        _configuration    = serializedObject.FindProperty("_configuration");
        _oscAddress = serializedObject.FindProperty("_oscAddress");
        _dataType   = serializedObject.FindProperty("_dataType");

        _event           = serializedObject.FindProperty("_event");
        _intEvent        = serializedObject.FindProperty("_intEvent");
        _floatEvent      = serializedObject.FindProperty("_floatEvent");
        _stringEvent     = serializedObject.FindProperty("_stringEvent");
        _vector2Event    = serializedObject.FindProperty("_vector2Event");
        _vector3Event    = serializedObject.FindProperty("_vector3Event");
        _vector4Event    = serializedObject.FindProperty("_vector4Event");
        _vector2IntEvent = serializedObject.FindProperty("_vector2IntEvent");
        _vector3IntEvent = serializedObject.FindProperty("_vector3IntEvent");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.ObjectField(_configuration, Labels.Configuration);
        EditorGUILayout.DelayedTextField(_oscAddress, Labels.OSCAddress);
        EditorGUILayout.PropertyField(_dataType);

        if (!_dataType.hasMultipleDifferentValues)
        {
            switch ((DataType)_dataType.enumValueIndex)
            {
                case DataType.None:       EditorGUILayout.PropertyField(_event);           break;
                case DataType.Int:        EditorGUILayout.PropertyField(_intEvent);        break;
                case DataType.Float:      EditorGUILayout.PropertyField(_floatEvent);      break;
                case DataType.String:     EditorGUILayout.PropertyField(_stringEvent);     break;
                case DataType.Vector2:    EditorGUILayout.PropertyField(_vector2Event);    break;
                case DataType.Vector3:    EditorGUILayout.PropertyField(_vector3Event);    break;
                case DataType.Vector4:    EditorGUILayout.PropertyField(_vector4Event);    break;
                case DataType.Vector2Int: EditorGUILayout.PropertyField(_vector2IntEvent); break;
                case DataType.Vector3Int: EditorGUILayout.PropertyField(_vector3IntEvent); break;
            }
        }

        serializedObject.ApplyModifiedProperties();
    }
}

