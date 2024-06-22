using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GuestGrading : MonoBehaviour
{
    public SpriteRenderer sprite;

    public float maxScale = 1.5f;
    public float duration = .3f;
    public float speed = 1f;
    public float alphaSpeed = 2f;

    private Coroutine coroutine;
    private Vector3 lastPosition;
    //크기 커졌다 돌아오기
    //위로 이동하기
    //흐려지기

    private void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            this.transform.position = lastPosition;
            sprite.gameObject.SetActive(true);// enabled = true;
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = StartCoroutine(DisplayScore());
        }
    }

    IEnumerator DisplayScore()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * maxScale;
        Color originalColor = sprite.color;
        float elapsedTime = 0f;

        // Scale up
        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Scale down to original size
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Move up and fade out
        elapsedTime = 0f;
        while (sprite.color.a > 0)
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            sprite.color = new Color(originalColor.r, originalColor.g, originalColor.b, Mathf.Lerp(originalColor.a, 0, elapsedTime / alphaSpeed));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        sprite.gameObject.SetActive(false);
        sprite.color = originalColor;
        this.transform.position = lastPosition;
    }
}
