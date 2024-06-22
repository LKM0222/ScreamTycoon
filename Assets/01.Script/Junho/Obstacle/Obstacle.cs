using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Act_type{
    key,
    mouse
}
public class Obstacles{
    public List<Obstacle> root;
}

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
}
