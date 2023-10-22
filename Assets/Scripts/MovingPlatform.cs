using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private Vector3 _LocationA;
    private Vector3 _LocationB;
    private Vector3 _nextLocation;

    [SerializeField]
    private Transform _platform;
    [SerializeField]
    private Transform MovingToLocation;

    public float speed;
    void Start()
    {
        _LocationA = _platform.localPosition;
        _LocationB = MovingToLocation.localPosition;
        _nextLocation = _LocationB;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        _platform.localPosition = Vector3.MoveTowards(_platform.localPosition, _nextLocation, speed * Time.deltaTime);

        if (Vector3.Distance(_platform.localPosition, _nextLocation) <= 0.1)
        {
            ChangePosition();
        }
    }

    private void ChangePosition()
    {
        _nextLocation = _nextLocation != _LocationA ? _LocationA : _LocationB;
    }
}
