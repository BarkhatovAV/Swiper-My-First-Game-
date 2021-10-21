using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private int _capacity;

    private Camera _camera;

    private List<GameObject> _pool = new List<GameObject>();

    protected void Initialize(List<GameObject> prefabs)
    {
        _camera = Camera.main;

        for (int i = 0; i < _capacity; i++)
        {
            int numberEnemy = Random.Range(0, prefabs.Count);

            GameObject spawned = Instantiate(prefabs[numberEnemy], transform);
            spawned.SetActive(false);

            _pool.Add(spawned);
        }
    }

    protected bool TryGetObject(out GameObject result)
    {
        bool GameObjectFinded = false;
        GameObject randomGameObject = null; ;

        while (GameObjectFinded == false)
        {
            randomGameObject = _pool[Random.Range(0, _pool.Count)];
            if (randomGameObject.activeSelf == false)
            {
                GameObjectFinded = true;
            }
            
        }
        result = randomGameObject;
        return result != null;

        //result = _pool.FirstOrDefault(p => p.activeSelf == false);
    }

    protected void DisableObjectAbroadScreen()
    {
        foreach (var item in _pool)
        {
            if (item.activeSelf == true)
            {
                if (item.transform.position.z < _camera.transform.position.z)
                {
                    item.SetActive(false);
                }
            }
        }
    }

    public void ResetPool()
    {
        foreach (var item in _pool)
        {
            item.SetActive(false);
        }
    }
}
