using System.Collections;
using System.Collections.Generic;
using PathCreation;
using PathCreation.Examples;
using UnityEngine;

public class OSCTest : MonoBehaviour
{
    [SerializeField] private PathFollower _pathFollower;
    [SerializeField] private float _velocityScale = 10f;
    
    public void TestFloat(float val)
    {
        Debug.Log($"{this} recieved float {val}");

        _pathFollower.speed = _velocityScale * val;
    }

    public void TestInt(int val)
    {
        Debug.Log($"{this} recieved int {val}");

        _pathFollower.enabled = val != 0;
    }
}
