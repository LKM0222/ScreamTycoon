using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FinalUI : MonoBehaviour
{
    [SerializeField] TMP_Text customer;
    [SerializeField] TMP_Text income;
    [SerializeField] TMP_Text evaluate;
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text spend;

    [SerializeField] GameObject gameoverUI;

    [SerializeField] Sprite overSp;
    [SerializeField] Sprite clearSp;
    private void OnEnable() {
        customer.text = "총 " + GameManager.Instance.finalCustomer+"명의 손님 방문";
        income.text = "누적 수익 - " +GameManager.Instance.finalIncome;
        evaluate.text = "누적 입소문 - " +GameManager.Instance.evaluate;
        score.text = "누적 점수 - " +GameManager.Instance.fianlScore;
        spend.text = "총 투자금 - " +GameManager.Instance.finalSpend;
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)){
            gameoverUI.SetActive(true);
            if(GameManager.Instance.finalSpend > GameManager.Instance.finalIncome)
                gameoverUI.GetComponent<SpriteRenderer>().sprite = overSp;
            else{
                gameoverUI.GetComponent<SpriteRenderer>().sprite = clearSp;
            }
        }
    }
}
