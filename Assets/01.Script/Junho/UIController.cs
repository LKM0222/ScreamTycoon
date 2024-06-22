using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text incomText;
    [SerializeField] TMP_Text evaluText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        scoreText.text = GameManager.Instance.score.ToString();
        incomText.text = GameManager.Instance.income.ToString();
        evaluText.text = GameManager.Instance.evaluate.ToString();
        
    }
}
