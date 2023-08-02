using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearSceneUI : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void GameEnd()
    {
        Application.Quit();
    }
}
