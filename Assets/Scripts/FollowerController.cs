using PathCreation.Examples;
using UnityEngine;

public class FollowerController : MonoBehaviour
{
    [SerializeField] private PathFollower _pathFollower;

    private float _referenceSpeed;
    private Vector3 _referenceScale;
    
    protected void Awake()
    {
        _referenceSpeed = _pathFollower.speed * 0.5f;
        _referenceScale = _pathFollower.transform.localScale *0.5f; 
    }

    public void SetSpeed(float val)
    {
        Debug.Log($"{this} recieved speed {val}");
        _pathFollower.speed = _referenceSpeed * val;
    }

    public void SetEnabled(int val)
    {
        Debug.Log($"{this} recieved enable {val}");
        _pathFollower.enabled = val != 0;
    }

    public void SetScale(float val)
    {
        Debug.Log($"{this} recieved scale {val}");
        _pathFollower.transform.localScale = _referenceScale * val;
    }
}
