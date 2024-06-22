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

        GameObject go = Instantiate(_prefab, this.transform);
        var temp = go.GetComponent<TestMoving>();
        var data = DataManager.Instance.GetCustomerData(temp);
        temp.speed = data.customer_speed;  //Gorani 여기 손님 속도 관련해서 만져줘야해요: 여기서 초기화했어요

    }

}
