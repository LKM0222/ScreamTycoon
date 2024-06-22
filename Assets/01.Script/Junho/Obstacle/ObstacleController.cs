using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    #region Singleton
    private static ObstacleController _instance;
    public static ObstacleController Instance{
        get{
            if(_instance == null)
                _instance = FindObjectOfType(typeof(ObstacleController)) as ObstacleController;

            return _instance;
        }
    }
    #endregion
    public bool hitFlag = false;//노트를 맞췄을 때 true

    public int objNum; //파싱된 데이터에서 불러옴.
    public GameObject obstacleobj;

    
    [SerializeField] bool spawnFlag = true; //손님이 스폰되었을때 (나중에 수정필요)
    

    // Update is called once per frame
    void Update()
    {
        if(spawnFlag){
            StartCoroutine(HitDetectCoroutine());
            spawnFlag = false;
        }
    }

    public IEnumerator HitDetectCoroutine(){
        yield return new WaitUntil(() => hitFlag == true); //플래그를 잘 맞췄다면
        obstacleobj.gameObject.SetActive(!hitFlag); //장애물 활성화
        yield return new WaitForSeconds(1f); //1초 기다린후에
        hitFlag = false;
        obstacleobj.gameObject.SetActive(!hitFlag);

    }
}
