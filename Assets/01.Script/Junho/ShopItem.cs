using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

[Serializable]
public class ShopItem : MonoBehaviour
{   
    [SerializeField] Obstacle obstacle; //기물
    //UI
    [SerializeField] Image itemImg; //아이템 이미지
    [SerializeField] TMP_Text itemEvalu; //요구 입소문
    [SerializeField] TMP_Text itemName; //아이템 이름
    [SerializeField] TMP_Text itemTooltip; //아이템 툴팁
    [SerializeField] TMP_Text itemValue; //아이템 가격
    [SerializeField] Button itemButBtn; //구매 버튼

    //Data
    [SerializeField] int needEvalu; //필요한 입소문 요구치

    private void OnEnable() {
        //데이터에 따라 아이템 구현
    }
    

    // Update is called once per frame
    void Update()
    {
        if(needEvalu >= GameManager.Instance.evaluate){
            itemButBtn.gameObject.SetActive(true);
        }
    }

    #region public method
    public void SetItem(){
        itemImg.sprite = obstacle.obstacleImg; //아이템 이미지
        itemEvalu.text = obstacle.maintenance_cost.ToString(); //요구 입소문
        itemName.text = obstacle.obstacle_type; //아이템 이름
        itemTooltip.text = "아이템이다."; //아이템 툴팁
        // itemValue; //아이템 가격
        // itemButBtn; //구매 버튼
    }

    public void OnBuyBtnClick(){ //아이템 구매 버튼 눌렀을 때

    }
    #endregion
}
