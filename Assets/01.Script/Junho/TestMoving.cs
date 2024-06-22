using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoving : MonoBehaviour
{
    [SerializeField] float speed;
    bool targetClicked;
    // Update is called once per frame
    void Update()
    {
        if(targetClicked)
            this.gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
    }

    private void OnMouseDown() {
        targetClicked = true;
    }

    private void OnBecameInvisible() {
        Destroy(this.gameObject);
    }
}
