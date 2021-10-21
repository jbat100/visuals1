using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.Animations;
#endif

public class RecordTransformHierarchy : MonoBehaviour
{
    [SerializeField] private AnimationClip _clip;

    [SerializeField] private float _period;

#if UNITY_EDITOR
    
    private GameObjectRecorder _recorder;
    private float _currentTime;
    
    void OnEnable()
    {
        // Create recorder and record the script GameObject.
        _recorder = new GameObjectRecorder(gameObject);

        // Bind all the Transforms on the GameObject and all its children.
        _recorder.BindComponentsOfType<Transform>(gameObject, true);

        _currentTime = 0f;
    }

    void LateUpdate()
    {
        if (!_clip)
        {
            return;
        }

        _currentTime += Time.deltaTime;

        if (_currentTime > _period)
        {
            // Take a snapshot and record all the bindings values for this frame.
            _recorder.TakeSnapshot(_currentTime);
            _currentTime -= _period;
        }
    }

    void OnDisable()
    {
        if (_clip == null)
        {
            return;
        }

        if (_recorder.isRecording)
        {
            // Save the recorded session to the clip.
            _recorder.SaveToClip(_clip);
        }
    }
#endif
}