using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float length;

    [SerializeField] HitboxController hitboxParent;

    // Update is called once per frame
    void Update()
    {
        this.transform.localScale = new Vector3(length,this.transform.localScale.y);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Detector"){
            hitboxParent.hitCount += 1;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.tag == "Detector"){
            hitboxParent.hitCount = 0;
        }
    }
}
