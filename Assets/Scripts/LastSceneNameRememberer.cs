using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastSceneNameRememberer : MonoBehaviour
{
    public string lastSceneName;

    private void Awake()
    {
        lastSceneName = SceneManager.GetActiveScene().name;

        DontDestroyOnLoad(gameObject);
    }

}
