using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    private Vector3 _LocationA;
    private Vector3 _LocationB;
    private Vector3 _nextLocation;

    [SerializeField]
    private Transform _rock;
    [SerializeField]
    private Transform MovingToLocation;
    [SerializeField]
    private Transform startToLocation;

    public float speed;

    private float _creatTime = 5f;
    private Transform currentRock;

    private void Start()
    {
        InvokeRepeating("CreateRock", _creatTime, _creatTime);

        _LocationA = startToLocation.localPosition;
        _LocationB = MovingToLocation.localPosition;
        _nextLocation = _LocationB;
    }

    private void CreateRock()
    {
        if (currentRock != null)
        {
            Destroy(currentRock.gameObject);
        } 
        currentRock= Instantiate(_rock, startToLocation.position, Quaternion.identity);
        
    }
    void Update()
    {
        Move();
        
    }

    private void Move()
    {
        _rock.localPosition = Vector3.MoveTowards(_rock.localPosition, _nextLocation, speed * Time.deltaTime);

        if (Vector3.Distance(_rock.localPosition, _nextLocation) <= 0.1)
        {
            ChangePosition();
        }
    }

    private void ChangePosition()
    {
        _nextLocation = _nextLocation != _LocationA ? _LocationA : _LocationB;
        
    }
   
}
