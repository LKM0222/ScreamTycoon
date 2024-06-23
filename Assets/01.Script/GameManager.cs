using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Singletone
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
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

    [Header("Clear")]
    public int clear_customer;
    public int clear_perfect;
    public int clear_near;
    public int clear_fail;
    public int clear_income;
    public int clear_evalu;

    [Header("Etc")]
    [SerializeField] TMP_Text timeText;
    [SerializeField] AudioSource audio;

    [Header("Staff Flag")] //Gorani 여기 스태프 플래그 만들어뒀는데 플래그 true일때 지정된 스태프가 활성화되도록 하면 될것같아요
    //public bool dollStaff; //인형스태프  //인형스태프는 구현이 조금 복잡하던데 어떻게 해야될지 기획자와 한번 상의해보셔야될거같아요
    public Action<bool> DollStaffAction;
    public bool IsEnterStaff;
    public bool IsLostStaff;

    //New Spawn Guest Action
    public Action NewSpawnAction;

    public GameObject[] lostObjs;

    [Header("Final")]
    public int finalCustomer;
    public int finalIncome;
    public int fianlScore;
    public int finalSpend;
    

    #region Time
    int minute;
    int second;
    #endregion

    public GameObject[] staffs;

    int turnnum;


    #region LifeCycle
    private void Start()
    {
        StartCoroutine(StartTimer()); //제일 처음 실행할때 타이머
    }

    #endregion

    #region public method
    public void TurnFinish()
    { //턴 클리어 시 분기를 계산하는 부분
        if (score < DataManager.Instance.level[0])
        {
            UIController.Instance.OpenFailUI();
        }
        else
        {
            UIController.Instance.OpenClearUI();
        }
    }

    public void ReStart()
    {
        if(turnnum >= DataManager.Instance.level.Length){
            UIController.Instance.FinalUI.SetActive(true);
        }
        else{
            audio.Play();
            clear_customer = 1; //방문수 1으로 초기화
            finalIncome += clear_income; //번 돈 저장
            fianlScore += score; //누적 점수 저장
            if(IsEnterStaff) //유지비용
                finalSpend += 100;
            if(IsLostStaff)
                finalSpend += 300;

            score = 0; //스테이지 점수 0으로 초기화
            turnnum ++; //스테이지 레벨
            StartCoroutine(StartTimer()); //타이머 활성화
        }
    }


    #endregion


    #region Coroutine
    public IEnumerator StartTimer()
    {
        curTime = time;
        while (curTime > 0)
        {
            curTime -= Time.deltaTime;
            minute = (int)curTime / 60;
            second = (int)curTime % 60;
            timeText.text = minute.ToString("00") + ":" + second.ToString("00");
            yield return null;

            if (curTime <= 0)
            {
                Debug.Log("시간 종료");
                TurnFinish();
                curTime = 0;
                yield break;
            }
        }
    }
    #endregion

}
//충돌해결