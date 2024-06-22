using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPrefab : MonoBehaviour
{
    [SerializeField] GameObject customerPrefab;
    public void Spawn(){
        print("Spawn");
        GameObject go = Instantiate(customerPrefab);
        go.transform.SetParent(this.transform);
    }
    
}
