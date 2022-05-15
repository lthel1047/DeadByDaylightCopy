using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

    public void ChangeGameScene()
    {
        SceneManager.LoadScene("Intro1");
    }
    public void BackScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
    public void StartScene()
    {
        SceneManager.LoadScene("Game");
    }
}
