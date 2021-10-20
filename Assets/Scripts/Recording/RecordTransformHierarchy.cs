using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.Animations;
#endif

public class RecordTransformHierarchy : MonoBehaviour
{
    [SerializeField]
    private AnimationClip _clip;

#if UNITY_EDITOR
    private GameObjectRecorder _Recorder;

    void Start()
    {
        // Create recorder and record the script GameObject.
        _Recorder = new GameObjectRecorder(gameObject);

        // Bind all the Transforms on the GameObject and all its children.
        _Recorder.BindComponentsOfType<Transform>(gameObject, true);
    }

    void LateUpdate()
    {
        if (!_clip)
            return;

        // Take a snapshot and record all the bindings values for this frame.
        _Recorder.TakeSnapshot(Time.deltaTime);
    }

    void OnDisable()
    {
        if (_clip == null)
            return;

        if (_Recorder.isRecording)
        {
            // Save the recorded session to the clip.
            _Recorder.SaveToClip(_clip);
        }
    }
#endif
}