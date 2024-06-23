using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    public void GameStart(){
        SceneManager.LoadScene("Juno 1");
    }

    public void GameQuit(){
        Application.Quit();
    }

    public void GoToTitle(){
        SceneManager.LoadScene("TitleScene");
    }
}
