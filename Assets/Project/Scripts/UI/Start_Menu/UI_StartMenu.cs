using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_StartMenu : MonoBehaviour
{
    
    public void OnClickPlay()
    {
        SceneManager.LoadScene(1);
        GameManager.Instance.GameRestarted();
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
