using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LostObject : MonoBehaviour
{
    private void Start() {
        StartCoroutine(LostWait());
    }
    private void OnMouseDown() {
        GameManager.Instance.score += DataManager.Instance.GetObstacle(6).perfect_score;
        Destroy(this.gameObject);
    }

    IEnumerator LostWait(){
        yield return new WaitForSeconds(5f);
        GameManager.Instance.score += DataManager.Instance.GetObstacle(6).fail_score;
        Destroy(this.gameObject);
    }

}
