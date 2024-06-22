using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UIController : MonoBehaviour
{   
    [Header("Main")]
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text incomText;
    [SerializeField] TMP_Text evaluText;

    [Header("Store")]
    [SerializeField] TMP_Text shopIncome;
    [SerializeField] TMP_Text shopEvalu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
}
