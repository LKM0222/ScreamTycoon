using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HitboxController : MonoBehaviour
{
    #region Singleton
    private static HitboxController _instance;
    public static HitboxController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType(typeof(HitboxController)) as HitboxController;

            return _instance;
        }
    }
    #endregion

    [SerializeField] KeyCode keyCode;
    [SerializeField] ObstacleController obstacleController;
    public bool pressKey = true;
    //나중에 초기화할 오브젝트
    public GameObject customerObj;

    public int hitCount;
    private void Update()
    {
        if (Input.GetKeyDown(keyCode) && pressKey)
        {
            //hitbox에 들어가는 오브젝트가 있을 경우 키를 눌렀을 때 활성화 되야함.
            // 중복검사 방지해야됨.
            pressKey = false; //한번 키를 눌렀으면 다시 못누르게

            //손님데이터 받아와야하는곳 Gorani
            var temp = customerObj.GetComponent<TestMoving>();
            var guestData = DataManager.Instance.GetCustomerData(temp);

            switch (hitCount)
            {
                case 2: //perfect
                    obstacleController.hitFlag = true;
                    GameManager.Instance.score +=
                        ObstacleController.Instance.obstacleobj.GetComponent<Obstacle>().obstacle.perfect_score; //오브젝트별 점수, 등등 다 받아야됨.
                                       
                    GameManager.Instance.clear_evalu += guestData.mouth_value; //손님이 제공하는 입소문
                    GameManager.Instance.clear_income += guestData.bonus_money;// 100; //손님이 지불하는 돈

                    GameManager.Instance.evaluate += 5;
                    GameManager.Instance.income += 100;

                    GameManager.Instance.clear_perfect += 1;
                    GameManager.Instance.clear_customer += 1;
                    print("perfect!" + keyCode);
                    break;
                case 1: //Near
                    obstacleController.hitFlag = true;
                    GameManager.Instance.score +=
                        ObstacleController.Instance.obstacleobj.GetComponent<Obstacle>().obstacle.good_score; //오브젝트별 점수, 등등 다 받아야됨.

                    ////손님 데이터 받아와야하는곳 Gorani
                    GameManager.Instance.clear_evalu += 5;//손님이 제공하는 입소문
                    GameManager.Instance.clear_income += 100;//손님이 지불하는 돈

                    GameManager.Instance.evaluate += 5;
                    GameManager.Instance.income += 100;

                    GameManager.Instance.clear_near += 1;
                    GameManager.Instance.clear_customer += 1;
                    print("Near!" + keyCode);
                    break;
                default: //bad
                    //bad일때는 어떤 작업 할지 작성
                    GameManager.Instance.score +=
                        ObstacleController.Instance.obstacleobj.GetComponent<Obstacle>().obstacle.fail_score; //오브젝트별 점수, 등등 다 받아야됨.

                    GameManager.Instance.clear_fail += 1;
                    print("bad.." + keyCode);
                    break;
            }
        }

    }

}
