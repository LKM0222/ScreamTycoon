using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitboxController : MonoBehaviour
{
    #region Singleton
    private static HitboxController _instance;
    public static HitboxController Instance{
        get{
            if(_instance == null)
                _instance = FindObjectOfType(typeof(HitboxController)) as HitboxController;

            return _instance;
        }
    }
    #endregion

    [SerializeField] KeyCode keyCode;
    [SerializeField] ObstacleController obstacleController;
    
    //나중에 초기화할 오브젝트
    GameObject customerObj;
    
    public int hitCount;
    private void Update() {
        if(Input.GetKeyDown(keyCode)){
            //hitbox에 들어가는 오브젝트가 있을 경우 키를 눌렀을 때 활성화 되야함.
            switch(hitCount){
                case 2: //perfect
                    obstacleController.hitFlag = true;
                    GameManager.Instance.clear_score += 
                        ObstacleController.Instance.obstacleobj.GetComponent<Obstacle>().perfect_score; //오브젝트별 점수, 등등 다 받아야됨.
                    GameManager.Instance.clear_evalu += 5;
                    GameManager.Instance.clear_income += 100;

                    GameManager.Instance.clear_perfect += 1;
                    GameManager.Instance.clear_customer += 1;
                    print("perfect!" + keyCode);
                break;
                case 1: //Near
                    obstacleController.hitFlag = true;
                    GameManager.Instance.clear_score += 
                        ObstacleController.Instance.obstacleobj.GetComponent<Obstacle>().good_score; //오브젝트별 점수, 등등 다 받아야됨.
                    GameManager.Instance.clear_evalu += 5; //이건 손님 데이터 와야 불러올듯.
                    GameManager.Instance.clear_income += 100;

                    GameManager.Instance.clear_near += 1;
                    GameManager.Instance.clear_customer += 1;
                    print("Near!" + keyCode);
                break;
                default: //bad
                    //bad일때는 어떤 작업 할지 작성
                    GameManager.Instance.clear_score += 
                        ObstacleController.Instance.obstacleobj.GetComponent<Obstacle>().fail_score; //오브젝트별 점수, 등등 다 받아야됨.
                    
                    GameManager.Instance.clear_fail += 1;
                    print("bad.." + keyCode);
                break;
            }
        }
    }
}
