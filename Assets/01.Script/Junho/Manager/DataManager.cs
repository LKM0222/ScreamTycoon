using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    //게임 내 레벨 디자인, 상품 가격, 손님 특성 등등 파싱하는 스크립트
    #region Singleon
    private static DataManager _intance;
    public static DataManager Instance{
        get{
            if(_intance == null)
                _intance = FindObjectOfType(typeof(DataManager)) as DataManager;
            
            return _intance;
        }
    }
    #endregion

    [Header("TextAssets")]
    public TextAsset obstacle_json;


    [Header("Data")]
    public int[] level = new int[0]; //스테이지 레벨
    public List<Obstacle> obstaclelist;

    #region public Method
    public void ParsingObstacleData(){
        Obstacles obstacles = JsonUtility.FromJson<Obstacles>(obstacle_json.text);

        foreach(Obstacle item in obstacles.root){
            obstaclelist.Add(item);
        }
    }

        

    #endregion
    


}
