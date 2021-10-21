using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MistakePanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private SwipeZone _swipeZone;
    [SerializeField] private float _duration;

    private float _currentTime;
    private float _normalizedCurrentTime;

    private void Start()
    {
        _canvasGroup.alpha = 0f;
    }

    private void OnEnable()
    {
        _swipeZone.CubeSkipped += OnCubeSkipped;
    }

    private void OnDisable()
    {
        _swipeZone.CubeSkipped -= OnCubeSkipped;
    }

    private void OnCubeSkipped()
    {
        _currentTime = 0;
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        while(_currentTime < _duration)
        {
            _currentTime += Time.deltaTime;
            _normalizedCurrentTime = _currentTime / _duration;
            _canvasGroup.alpha =1-_normalizedCurrentTime;

            yield return null;
        }
    }
}
