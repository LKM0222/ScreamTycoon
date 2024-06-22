using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{

    #region Singletone
    private static DataManager _instance;
    public static DataManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType(typeof(DataManager)) as DataManager;

            return _instance;
        }
    }
    #endregion
    //게임 내 레벨 디자인, 상품 가격, 손님 특성 등등 파싱하는 스크립트


    [Header("Data")]
    public int[] level = new int[0]; //스테이지 레벨
    public TextAsset jsonCustomer;
    public TextAsset jsonObstacle;

    public List<GameObject> customerPrefabs;

    public List<CustomerData> customers;
    [SerializeField] List<ObstacleData> obstacles;


    private void Awake()
    {
        customers = LoadJsonCustomers(jsonCustomer);
        obstacles = LoadJsonObstacles(jsonObstacle);
        SetCustomer();
    }
    public CustomerData GetCustomerData(TestMoving info)
    {
        if (info == null)
            return null;

        CustomerData data = null;
        var temp = info;
        switch (temp.guestType)
        {
            case GuestType.Couple:
                data = DataManager.Instance.customers.Find(x => x.customer_type == "couple");
                break;
            case GuestType.LittleGirl:
                data = DataManager.Instance.customers.Find(x => x.customer_type == "girl");
                break;
            case GuestType.Muscle:
                data = DataManager.Instance.customers.Find(x => x.customer_type == "strong_male");
                break;
            case GuestType.Streamer:
                data = DataManager.Instance.customers.Find(x => x.customer_type == "streamer");
                break;
        }
        return data;
    }


    private void SetCustomer()
    {
        int i = 0;
        foreach (var customer in customers)
        {
            var temp = customerPrefabs[i].GetComponent<TestMoving>();
            temp.speed = customer.customer_speed;
            i++;
        }
    }
    public ObstacleData GetObstacle(int obstaclenum)
    {
        return obstacles[obstaclenum];
    }


    private List<CustomerData> LoadJsonCustomers(TextAsset json)
    {
        CustomerDatas wrap = JsonUtility.FromJson<CustomerDatas>(json.text);
        var customerDatas = wrap.Items;

        return customerDatas;
    }

    private List<ObstacleData> LoadJsonObstacles(TextAsset json)
    {
        ObstacleDatas wrap = JsonUtility.FromJson<ObstacleDatas>(json.text);
        var obstacleDatas = wrap.Items;

        return obstacleDatas;
    }
}

[Serializable]
public class CustomerDatas
{
    public List<CustomerData> Items;
}

[System.Serializable]
public class CustomerData
{
    public string customer_type;
    public float customer_speed;
    public int bonus_score;
    public int bonus_money;
    public int mouth_value;
}

[Serializable]
public class ObstacleDatas
{
    public List<ObstacleData> Items;
}

[System.Serializable]
public class ObstacleData
{
    public string obstacle_type;
    public string act_type;
    public int mouth_condition;
    public int obstacle_price;
    public int maintenance_cost;
    public int perfect_score;
    public int good_score;
    public int fail_score;

    //etc
    public Sprite obstacleImg;
}
