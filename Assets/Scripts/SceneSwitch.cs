using System.Collections;
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
}
