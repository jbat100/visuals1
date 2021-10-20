using System;
using UnityEngine;
using UnityEngine.Events;

public class OculusControllerInput : MonoBehaviour
{
    [Serializable] public class RecordEvent : UnityEvent{ }

    [SerializeField] private RecordEvent _onRecord;
    
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
            _onRecord?.Invoke();
        }
    }
}
