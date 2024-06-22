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
    }
    public void OpenFailUI(){
        FailUI.SetActive(true);
    }
    public void OpenStoreUI(){
        StoreUI.SetActive(true);
    }

    
}
