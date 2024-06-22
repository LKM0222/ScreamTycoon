using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endline : MonoBehaviour
{
    [SerializeField] SpawnerPrefab spawner;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Detector")
        {
            print("detector");
            spawner.Spawn();
            GameManager.Instance.NewSpawnAction?.Invoke();
        }
    }
}
