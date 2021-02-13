using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsController : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Quit()
    {
        Debug.Log("Quited");
        Application.Quit();
    }
}
