using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollDragDrop : MonoBehaviour
{
    public Rigidbody2D rb2D;
    private bool isOnFloor;
    public float originalGravityScale = 1f;
    public float noGravityScale = 0f;

    public float dragSpeed = 100f;
    private bool isDragging = false;
    private Vector3 offset;

    //마우스 릴리즈시 인형 잠깐 커졌다 작아지는 효과를 위해
    public Vector3 targetScale = new Vector3(2f, 2f, 2f);
    public float duration = 1f;
    private Vector3 originalScale;
    private Coroutine coroutine;
    //
    void Start()
    {
        if (rb2D == null)
            rb2D = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void Update()
    {
        CheckDrag();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnFloor = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            isOnFloor = false;
        }
    }

    private void CheckDrag()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                isDragging = true;
                offset = transform.position - mousePosition;
                rb2D.gravityScale = 0;
                rb2D.velocity = Vector2.zero;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnRelease();
            isDragging = false;
            rb2D.gravityScale = 1;
        }

        if (isDragging)
        {
            Vector3 targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, dragSpeed * Time.deltaTime);
            rb2D.MovePosition(smoothedPosition);
        }

    }

    private void OnRelease()
    {
        if (isDragging == false)
            return;
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(Co_ScaleUpAndDown());
    }

    private IEnumerator Co_ScaleUpAndDown()
    {
        yield return ScaleTo(targetScale, duration);
        yield return ScaleTo(originalScale, duration);
    }

    private IEnumerator ScaleTo(Vector3 target, float duration)
    {
        Vector3 startScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(startScale, target, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localScale = target;
    }
}

