using Sonosthesia;
using UnityEngine;

public class PathFollower : MonoBehaviour
{
    [SerializeField] private Path _path;
    [SerializeField] private float _speed = 5;
    [SerializeField] private bool _local;

    public float Speed
    {
        get => _speed;
        set => _speed = value;
    }

    private float _distance;

    void Update()
    {
        _distance += _speed * Time.deltaTime;
        if (_local)
        {
            transform.localPosition = _path.Position(_distance);
            transform.localRotation = _path.Rotation(_distance);   
        }
        else
        {
            transform.position = _path.Position(_distance);
            transform.rotation = _path.Rotation(_distance);            
        }
    }
}
