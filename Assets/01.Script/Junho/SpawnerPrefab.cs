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
        }//prefab List�� ������� ����

        GameObject go = Instantiate(_prefab, this.transform);
        var temp = go.GetComponent<TestMoving>();
        var data = DataManager.Instance.GetCustomerData(temp);
        temp.speed = data.customer_speed;  //Gorani ���� �մ� �ӵ� �����ؼ� ��������ؿ�: ���⼭ �ʱ�ȭ�߾��

    }

}
