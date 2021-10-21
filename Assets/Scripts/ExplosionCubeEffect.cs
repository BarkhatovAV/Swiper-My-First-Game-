using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionCubeEffect : MonoBehaviour
{
    [SerializeField] private SwipeZone _swipeZone;
    [SerializeField] private GameObject _efect;

    private void OnEnable()
    {
        _swipeZone.CubeDestroyed += OnCubeDestroyed;
    }


    private void OnDisable()
    {
        _swipeZone.CubeDestroyed -= OnCubeDestroyed;
    }

    private void OnCubeDestroyed(Vector3 cubePosition,int angleOfRotation)
    {
        var efect = Instantiate(_efect, cubePosition, Quaternion.identity);
        efect.transform.rotation = Quaternion.Euler(angleOfRotation, 90, 0);
    }
}
