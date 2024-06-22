using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public enum Act_type{
    key,
    mouse
}
public class Obstacles{
    public List<Obstacle> root;
}

[Serializable]
public class Obstacle : MonoBehaviour
{   
    public string obstacle_type;
    public Act_type act_type;
    public int mouse_condition;
    public int obstacle_price;
    public int maintenance_cost;
    public int perfect_score;
    public int good_score;
    public int fail_score;

    //not parsing data
    public Sprite obstacleImg;

    public Obstacle returnObj(){
        return this;
    }

    public void SetObj(Obstacle obj){
        obstacle_type = obj.obstacle_type;
        act_type = obj.act_type;
        mouse_condition = obj.mouse_condition;
        obstacle_price = obj.obstacle_price;
        maintenance_cost = obj.maintenance_cost;
        perfect_score = obj.perfect_score;
        good_score = obj.good_score;
        fail_score = obj.fail_score;
    }
}
