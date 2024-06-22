using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoving : MonoBehaviour
{
    public float speed;
    bool targetClicked;
    public Animator animator;
    public GuestType guestType;

    private void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();
        animator.SetInteger("AniNumber", 0);
    }

    void Update()
    {
        if (targetClicked)
        {
            this.gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }
    }

    private void OnMouseDown()
    {
        targetClicked = true;
        animator.SetInteger("AniNumber", 1);
    }

    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}

public enum GuestType
{
    Couple,
    LittleGirl,
    Muscle,
    Streamer,
}
