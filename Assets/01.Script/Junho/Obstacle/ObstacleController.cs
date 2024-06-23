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
    public static ObstacleController Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType(typeof(ObstacleController)) as ObstacleController;

            return _instance;
        }
    }
    #endregion
    public bool hitFlag = false;//노트를 맞췄을 때 true

    public int objNum; //파싱된 데이터에서 불러옴.
    public GameObject obstacleobj; //현재 등록된 오브젝트
    [SerializeField] Sprite actionSprite; //액션 시 전환할 이미지
    [SerializeField] Sprite idleSprite; //기본 이미지

    [SerializeField] bool spawnFlag = true; //손님이 스폰되었을때 (나중에 수정필요)
    [SerializeField] HitboxController hitbodcontroller;
    private Coroutine coroutine;
    //private TestMoving lastCustomer;

    private void Start()
    {
        GameManager.Instance.NewSpawnAction -= ResetFlag;
        GameManager.Instance.NewSpawnAction += ResetFlag;
    }

    private void ResetFlag()
    {
        spawnFlag = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnFlag)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = StartCoroutine(HitDetectCoroutine());
            spawnFlag = false;
        }
    }


    public IEnumerator HitDetectCoroutine()
    {
        yield return new WaitUntil(() => hitFlag == true); //플래그를 잘 맞췄다면
        obstacleobj.GetComponent<SpriteRenderer>().sprite = actionSprite; //장애물 활성화
        var lastCustomer = hitbodcontroller.customerObj.GetComponent<TestMoving>();

        var temp = lastCustomer.speed; //원래 속도 저장
        lastCustomer.speed = 0f;//손님 잠시 멈춤 (상태변경)
        lastCustomer.animator.SetInteger("AniNumber", 2);

        yield return new WaitForSeconds(1f); //1초 기다린후에 전부 복구
        obstacleobj.GetComponent<SpriteRenderer>().sprite = idleSprite;
        lastCustomer.speed = temp;
        lastCustomer.animator.SetInteger("AniNumber", 1);
        hitFlag = false;
        obstacleobj.gameObject.SetActive(!hitFlag);

    }
}
