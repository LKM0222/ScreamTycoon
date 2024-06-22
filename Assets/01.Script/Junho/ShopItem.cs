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
    [SerializeField] int obstacleNum; //기물번호
    [SerializeField] ObstacleData obstacle; //기물
    //UI
    [SerializeField] Image itemImg; //아이템 이미지
    [SerializeField] TMP_Text itemEvalu; //요구 입소문
    [SerializeField] TMP_Text itemName; //아이템 이름
    [SerializeField] TMP_Text itemTooltip; //아이템 툴팁
    [SerializeField] TMP_Text itemValue; //아이템 가격
    [SerializeField] TMP_Text maintenanceText; //아이템 유지비
    [SerializeField] Button itemButBtn; //구매 버튼


    private void OnEnable() {
        obstacle = DataManager.Instance.GetObstacle(obstacleNum);
        SetItem();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }

    #region public method

    public void OnBuyBtnClick(){ //아이템 구매 버튼 눌렀을 때
        if(GameManager.Instance.income >= obstacle.obstacle_price){
            switch (obstacleNum)
            {
                case 4:
                    GameManager.Instance.dollStaff = true;
                break;
                case 5:
                    GameManager.Instance.enterStaff = true;
                break;
                case 6:
                    GameManager.Instance.lostStaff = true;
                break;
            }
            GameManager.Instance.income -= obstacle.obstacle_price; //구매완료 후 빼줌.
        }
        
    }
    #endregion

    #region pirvate method
    private void SetItem(){
        itemImg.sprite = obstacle.obstacleImg; //아이템 이미지
        itemEvalu.text = obstacle.mouth_condition.ToString(); //요구 입소문
        itemName.text = obstacle.obstacle_type; //아이템 이름
        itemValue.text = obstacle.obstacle_price.ToString(); //아이템 가격
        maintenanceText.text = "유지비 : " + obstacle.maintenance_cost.ToString(); //아이템 유지비
    }
    #endregion
}
