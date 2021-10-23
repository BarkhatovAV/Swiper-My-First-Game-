using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwipeZone : MonoBehaviour
{
    [SerializeField] private SwipeHandler _swipeHandler;
    [SerializeField] private int _angleOfRotationToLeft;
    [SerializeField] private int _angleOfRotationToRight;
    [SerializeField] private int _angleOfRotationToUp;
    [SerializeField] private int _angleOfRotationToDown;

    private �ubeDirection _cubeDirection;
    private GameObject _currentCube;
    private Transform _currentCubeTransform;

    public event UnityAction SwipeAccepted;
    public event UnityAction CubeSkipped;
    public event UnityAction<Vector3, int> CubeDestroyed;

    private void OnEnable()
    {
        _swipeHandler.SwipedUp += OnSwipedUp;
        _swipeHandler.SwipedDown += OnSwipedDown;
        _swipeHandler.SwipedLeft += OnSwipedLeft;
        _swipeHandler.SwipedRight += OnSwipedRight;
    }

    private void OnDisable()
    {
        _swipeHandler.SwipedUp -= OnSwipedUp;
        _swipeHandler.SwipedDown -= OnSwipedDown;
        _swipeHandler.SwipedLeft -= OnSwipedLeft;
        _swipeHandler.SwipedRight -= OnSwipedRight;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CubeUp _cubeUp) )
        {
            _cubeDirection = �ubeDirection.Up;
            _currentCube = other.gameObject;
        }

        if (other.TryGetComponent(out CubeDown _cubeDown))
        {
            _cubeDirection = �ubeDirection.Down;
            _currentCube = other.gameObject;
        }

        if (other.TryGetComponent(out CubeLeft _cubeLeft))
        {
            _cubeDirection = �ubeDirection.Left;
            _currentCube = other.gameObject;
        }

        if (other.TryGetComponent(out CubeRight _cubeRight))
        {
            _cubeDirection = �ubeDirection.Right;
            _currentCube = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CubeSkipped?.Invoke();
    }

    private void OnSwipedUp()
    {
        if(_cubeDirection == �ubeDirection.Up)
        {
            ImplementSwipe(_angleOfRotationToUp);
        }
    }

    private void OnSwipedDown()
    {
        if (_cubeDirection == �ubeDirection.Down)
        {
            ImplementSwipe(_angleOfRotationToDown);

        }
    }
    private void OnSwipedRight()
    {
        if (_cubeDirection == �ubeDirection.Right)
        {
            ImplementSwipe(_angleOfRotationToRight);

        }
    }

    private void OnSwipedLeft()
    {
        if (_cubeDirection == �ubeDirection.Left)
        {
            ImplementSwipe(_angleOfRotationToLeft);
        }
    }

    private void ImplementSwipe(int angleOfRotation)
    {
        SwipeAccepted?.Invoke();
        _currentCubeTransform = _currentCube.transform;
        CubeDestroyed?.Invoke(_currentCubeTransform.position,angleOfRotation);
        Destroy(_currentCube);
        
    }
}

public enum �ubeDirection
{
    Up,
    Down,
    Left,
    Right
}
