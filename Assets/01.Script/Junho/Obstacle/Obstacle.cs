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
    [SerializeField] ObstacleData obstacle;
    [SerializeField] int obstacleNum;

    private void Start() {
        obstacle = DataManager.Instance.GetObstacle(obstacleNum);
    }
    
}
