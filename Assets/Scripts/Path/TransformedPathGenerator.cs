using System;
using PathCreation;
using UnityEngine;

public class TransformedPathGenerator : MonoBehaviour
{
    [SerializeField] private PathCreator _followPathCreator;
    [SerializeField] private PathCreator _startPathCreator;
    [SerializeField] private PathCreator _endPathCreator;

    [SerializeField] private GameObject _providerPrefab;
    [SerializeField] private GameObject _followerPrefab;
    
    [SerializeField] private int _steps;
    
    
    protected void OnEnable()
    {
        _steps = Mathf.Max(2, _steps);
        
        float step = 1f / (_steps - 1);



    }

    protected void OnDisable()
    {
        
    }
}
