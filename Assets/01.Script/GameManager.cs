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

    [Header("Time")]
    public float time;
    public float curTime;

    int minute;
    int second;
    [SerializeField] TMP_Text timeText;

    
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