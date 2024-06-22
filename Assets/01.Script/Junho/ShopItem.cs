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
    //UI
    [SerializeField] Image itemImg; //아이템 이미지
    [SerializeField] TMP_Text itemEvalu; //요구 입소문
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
    public void OnBuyBtnClick(){ //아이템 구매 버튼 눌렀을 때

    }
    #endregion
}
