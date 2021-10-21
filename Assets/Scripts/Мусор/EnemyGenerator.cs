using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : ObjectPool
{
    [SerializeField] private List <GameObject> _templates;
    [SerializeField] private float _secondBetweenSpawn;

    private float _elapsedTime = 0;

    private void Start()
    {
        Initialize(_templates);
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;

        if (_elapsedTime > _secondBetweenSpawn)
        {
            if (TryGetObject(out GameObject enemy))
            {
                _elapsedTime = 0;
                enemy.SetActive(true);
                enemy.transform.position = transform.position;
            }
        }

        DisableObjectAbroadScreen();

    }
}
