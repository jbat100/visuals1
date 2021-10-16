using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EventReceiverConfiguration", menuName = "EventReceiverConfiguration", order = 100)]
public class EventReceiverConfiguration : ScriptableObject
{
    [SerializeField] int _udpPort = 9000;
    public int UDPPort => _udpPort;
}
