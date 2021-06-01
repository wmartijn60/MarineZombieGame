﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void SwitchScene(int MyScene)
    {
        SceneManager.LoadScene(MyScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SelectScene(int scene)
    {

        SceneManager.LoadScene(sceneBuildIndex: scene);

    }
    public void ButtonSelectSceneWithDelay(int scene)
    {

        StartCoroutine(LoadSceneAfterDelay(scene, 0.3f));

    }
    public void LoadSceneWithDelay(int sceneName, float delay)
    {
        StartCoroutine(LoadSceneAfterDelay(sceneName, delay));
    }

    private IEnumerator LoadSceneAfterDelay(int sceneName, float delay)
    {
        if (delay > 0)
            yield return new WaitForSeconds(delay);

        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        yield break;
    }
}
