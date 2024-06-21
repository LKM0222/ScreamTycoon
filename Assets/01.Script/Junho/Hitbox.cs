using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float length;

    public GameObject customoer;

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = new Vector3(length,this.transform.localScale.y);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Customer"){
            customoer = other.gameObject;
        }
    }
}
