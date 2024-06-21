using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public bool hitFlag = false;//노트를 맞췄을 때 true

    [SerializeField] GameObject obstacle;
    
    bool spawnFlag = true; //손님이 스폰되었을때 (나중에 수정필요)
 
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
        obstacle.SetActive(hitFlag); //장애물 활성화
        yield return new WaitForSeconds(1f); //1초 기다린후에
        hitFlag = false;
        obstacle.SetActive(hitFlag);

    }
}
