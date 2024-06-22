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

    Hitbox coolBox;
    [SerializeField] KeyCode keyCode;
    [SerializeField] ObstacleController obstacleController;
    
    public int hitCount;
    private void Update() {
        if(Input.GetKeyDown(keyCode)){
            //hitbox에 들어가는 오브젝트가 있을 경우 키를 눌렀을 때 활성화 되야함.
            switch(hitCount){
                case 3: //perfect
                    obstacleController.hitFlag = true;
                    GameManager.Instance.score += 100;
                    print("perfect!" + keyCode);
                break;
                case 2: //Good
                    obstacleController.hitFlag = true;
                    GameManager.Instance.score += 50;
                    print("good!" + keyCode);
                break;
                case 1: //Cool
                    obstacleController.hitFlag = true;
                    GameManager.Instance.score += 30;
                    print("cool!" + keyCode);
                break;
                default: //bad
                    //bad일때는 어떤 작업 할지 작성
                    print("bad.." + keyCode);
                break;
            }
        }
    }
}
