using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SwipeHandler : MonoBehaviour
{
    [SerializeField] private float _deadZone;

    private Vector2 _tapPosition;
    private Vector2 _swipeDelta;

    private bool _isSwiping;
    private bool _isMobile;

    public event UnityAction SwipedUp;
    public event UnityAction SwipedDown;
    public event UnityAction SwipedRight;
    public event UnityAction SwipedLeft;

    private void Start()
    {
        _isMobile = Application.isMobilePlatform;
    }

    private void Update()
    {
        if (!_isMobile)
        {
            TrackMouseClick();
        }
        else
        {
            TrackTouch();
        }

        RecognizeSwipe();
    }

    private void TrackMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isSwiping = true;
            _tapPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ResetSwipe();
        }
    }

    private void TrackTouch()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _isSwiping = true;
                _tapPosition = Input.GetTouch(0).position;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                ResetSwipe();
            }
        }
    }

    private void RecognizeSwipe()
    {
        UpdateSwipeDeltaValue();

        if (_swipeDelta.magnitude > _deadZone)
        {
            if (Mathf.Abs(_swipeDelta.x) > Mathf.Abs(_swipeDelta.y))
            {
                if(_swipeDelta.x > 0) SwipedRight?.Invoke();
                else SwipedLeft?.Invoke(); 
            }
            else
            {
                if(_swipeDelta.y > 0) SwipedUp?.Invoke();
                else SwipedDown?.Invoke();
            }
            ResetSwipe();
        }
    }

    private void UpdateSwipeDeltaValue()
    {
        _swipeDelta = Vector2.zero; 

        if (_isSwiping)
        {
            if (!_isMobile && Input.GetMouseButton(0))
            {
                _swipeDelta = (Vector2)Input.mousePosition - _tapPosition;
            }
            else if (Input.touchCount > 0)
            {
                _swipeDelta = Input.GetTouch(0).position - _tapPosition;
            }
        }

    }
    private void ResetSwipe()
    {
        _isSwiping = false;

        _tapPosition = Vector2.zero;
        _swipeDelta = Vector2.zero;
    }
}
