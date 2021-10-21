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

    private bool _isCubeUp = false;
    private bool _isCubeDown = false;
    private bool _isCubeLeft = false;
    private bool _isCubeRight = false;
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
        _isCubeUp = false;
        _isCubeDown = false;
        _isCubeLeft = false;
        _isCubeRight = false;

        if (other.GetComponent<CubeUp>() != null)
        {
            _isCubeUp = true;
            _currentCube = other.gameObject;
        }

        if (other.GetComponent<CubeDown>() != null)
        {
            _isCubeDown = true;
            _currentCube = other.gameObject;
        }
        if (other.GetComponent<CubeLeft>() != null)
        {
            _isCubeLeft = true;
            _currentCube = other.gameObject;
        }

        if (other.GetComponent<CubeRight>() != null)
        {
            _isCubeRight = true;
            _currentCube = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CubeSkipped?.Invoke();
    }

    private void OnSwipedUp()
    {
        if(_isCubeUp == true)
        {
            ImplementSwipe(_angleOfRotationToUp);
        }
    }

    private void OnSwipedDown()
    {
        if (_isCubeDown == true)
        {
            ImplementSwipe(_angleOfRotationToDown);

        }
    }
    private void OnSwipedRight()
    {
        if (_isCubeRight == true)
        {
            ImplementSwipe(_angleOfRotationToRight);

        }
    }

    private void OnSwipedLeft()
    {
        if (_isCubeLeft == true)
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
