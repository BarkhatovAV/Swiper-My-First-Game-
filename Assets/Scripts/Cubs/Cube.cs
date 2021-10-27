using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _changedColor;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _renderer.material.color = _changedColor;
    }

    private void OnTriggerExit(Collider other)
    {
        _renderer.material.color = _startColor;
    }
}
