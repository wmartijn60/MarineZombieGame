using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public int MyScene = 1;
public void Switch()
    {
        SceneManager.LoadScene(sceneBuildIndex: MyScene);
    }
}
