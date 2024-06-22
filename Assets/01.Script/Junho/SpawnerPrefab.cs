using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPrefab : MonoBehaviour
{
    //[SerializeField] List<GameObject> customerPrefab;
    private int curNumber = 0;

    public void Spawn()
    {
        //print("Spawn");
        var customerPrefab = DataManager.Instance.customerPrefabs;
        if (customerPrefab == null || customerPrefab.Count == 0)
            return;
        GameObject _prefab;
        if (curNumber < customerPrefab.Count - 1)
        {
            _prefab = customerPrefab[curNumber];
            curNumber++;
        }
        else
        {
            curNumber = 0;
            _prefab = customerPrefab[curNumber];
            curNumber++;
        }//prefab List의 순서대로 선택

        GameObject go = Instantiate(_prefab);
        go.transform.SetParent(this.transform);
    }

}
