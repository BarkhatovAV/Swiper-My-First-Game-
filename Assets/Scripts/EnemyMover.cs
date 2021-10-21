using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        transform.Translate(_direction.normalized * _speed);
    }
}
