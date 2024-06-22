using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{   
    #region Singletone
    private static UIController _instance;
    public static UIController Instance{
        get{
            if(_instance == null)
                _instance = FindObjectOfType(typeof(UIController)) as UIController;
            
            return _instance;
        }
    }
    #endregion
    [Header("Main")]
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text incomText;
    [SerializeField] TMP_Text evaluText;

    [Header("Store")]
    [SerializeField] TMP_Text shopIncome;
    [SerializeField] TMP_Text shopEvalu;

    [Header("UI")]
    [SerializeField] GameObject ClearUI;
    [SerializeField] GameObject FailUI;
    [SerializeField] GameObject StoreUI;

    [Header("ClearText")]
    [SerializeField] TMP_Text clear_customerText;
    [SerializeField] TMP_Text clear_perfectText;
    [SerializeField] TMP_Text clear_nearText;
    [SerializeField] TMP_Text clear_failText;
    [SerializeField] TMP_Text clear_incomeText;
    [SerializeField] TMP_Text clear_evaluText;
    [SerializeField] TMP_Text clear_scoreText;


    // Update is called once per frame
    void Update()
    {   
        //main
        scoreText.text = GameManager.Instance.score.ToString();
        incomText.text = GameManager.Instance.income.ToString();
        evaluText.text = GameManager.Instance.evaluate.ToString();
        
        //shop
        shopIncome.text = GameManager.Instance.income.ToString();
        shopEvalu.text = GameManager.Instance.evaluate.ToString();
    }

    public void OpenClearUI(){
        ClearUI.SetActive(true);
        SetCleartext();
    }
    public void OpenFailUI(){
        FailUI.SetActive(true);
    }
    public void OpenStoreUI(){
        StoreUI.SetActive(true);
    }

    public void SetCleartext(){
        clear_customerText.text = "총" + GameManager.Instance.clear_customer + "명의 손님 방문";
        clear_perfectText.text = "Perfect-" + GameManager.Instance.clear_perfect;
        clear_nearText.text = "Near-" + GameManager.Instance.clear_near;
        clear_failText.text = "Fail-" + GameManager.Instance.clear_fail;
        clear_incomeText.text = $"수익-" + GameManager.Instance.clear_income;
        clear_evaluText.text = "획득입소문-" + GameManager.Instance.clear_evalu;
        clear_scoreText.text = "획득점수-" + GameManager.Instance.clear_score;
    }
}
