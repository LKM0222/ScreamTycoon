using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoving : MonoBehaviour
{
    [SerializeField] float speed;
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
    }
}
