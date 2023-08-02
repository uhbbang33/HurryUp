using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject[] texts;
    LastSceneNameRememberer lastScene;
    private void Start()
    {
        StartCoroutine(RemoveText());

        lastScene = GameObject.Find("Last Scene name").GetComponent<LastSceneNameRememberer>();
    }

    IEnumerator RemoveText()
    {
        yield return new WaitForSeconds(5);
        for (int i = 0; i < texts.Length; ++i)
            texts[i].SetActive(false);
    }

    public void GoLastScene()
    {
        SceneManager.LoadScene(lastScene.lastSceneName, LoadSceneMode.Single);
    }

    public void GameEnd()
    {
        Application.Quit();
    }

}
