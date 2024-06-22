using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public int score;
    public int income;

    //입소문은 데이터가 어떻게 되지?
    //입소문 점수별로 데이터 : 뭐가 해금되고?
    //손님 데이터 (손님유형, 만족도별 점수? , 만족도별 수익, 손님 이동속도, 입소문 점수)
    //장애물 데이터 (종류, 작동방식, 해금조건, 가격)
    //제한시간 UI
    //상점 타이밍, 상점 UI
    //정산창 (하루 방문수, 실패수, perfect, good 이런거 횟수? )

    //update용 커밋
    

}
