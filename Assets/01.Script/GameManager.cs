using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singletone
    private static GameManager _instance;
    public static GameManager Instance{
        get{
            if(_instance == null)
                _instance = FindObjectOfType(typeof(GameManager)) as GameManager;
            
            return _instance;
        }
    }
    #endregion
    [Header("Data")]
    public int score;
    public int income;
    public int evaluate;

    [Header("Time")]
    public float time;
    public float curTime;

    int minute;
    int second;
    [SerializeField] TMP_Text timeText;
    private void Start() {
        StartCoroutine(StartTimer());
    }

    #region public method
    public void NextTurn(){//다음 플레이를 위한 초기화
        score = 0;
    }

    public void TurnFinish(){ //턴 클리어 시 분기를 계산하는 부분
        
    }
    #endregion

    
    #region Coroutine
    public IEnumerator StartTimer()
    {
        curTime = time;
        while(curTime > 0)
        {
            curTime -= Time.deltaTime;
            minute = (int)curTime / 60;
            second = (int)curTime % 60;
            timeText.text = minute.ToString("00") + ":" + second.ToString("00");
            yield return null;

            if(curTime <= 0)
            {
                Debug.Log("시간 종료");
                curTime = 0;
                yield break;
            }
        }
    }
    #endregion

}