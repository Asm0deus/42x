using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left, 
    Right
}
public class EnemyNoPhysics : MonoBehaviour
{
    [SerializeField] private Transform _targetA;
    [SerializeField] private Transform _targetB;

    [SerializeField] private float _speed;
    [SerializeField] private float _stopTime;

    [SerializeField] private Direction _currentDirection;

    public bool _isStopped;

    [SerializeField] private UnityEvent _eventOnLeftTarget;
    [SerializeField] private UnityEvent _eventOnRightTarget;

    [SerializeField] private Transform _rayStart;

    private void Start()
    {
        _targetA.parent = null;
        _targetB.parent = null;
    }

    private void Update()
    {
        if(_isStopped == true) return;

        if (_currentDirection == Direction.Left)
        {
            transform.position -= new Vector3(0f, 0f, Time.deltaTime * _speed);
            if (transform.position.z < _targetA.position.z)
            {
                _currentDirection = Direction.Right;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), _stopTime);
                _eventOnLeftTarget.Invoke();
            }
        }
        else
        {
            transform.position += new Vector3(0f, 0f, Time.deltaTime * _speed);
            if (transform.position.z > _targetB.position.z)
            {
                _currentDirection = Direction.Left;
                _isStopped = true;
                Invoke(nameof(ContinueWalk), _stopTime);
                _eventOnRightTarget.Invoke();
            }
        }
        RaycastHit hit;
        if (Physics.Raycast(_rayStart.position, Vector3.down, out hit))
        {
            transform.position = hit.point;
        }
    }

    private void ContinueWalk()
    {
        _isStopped = false;
    }
}
