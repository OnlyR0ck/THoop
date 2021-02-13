using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtonsController : MonoBehaviour
{
    #region Fields

    [SerializeField]private TextMeshProUGUI _vibrationText;


    #endregion

    #region Initialization

    private void Start()
    {
        _vibrationText.text = CameraController._enableVibration ? "Vibration\nON" : "Vibration\nOFF";
    }

    #endregion

    #region ButtonControllers
    
    public void LoadGameScene()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EnableVibration()
    {
        CameraController._enableVibration = !CameraController._enableVibration;
        _vibrationText.text = CameraController._enableVibration ? "Vibration\nON" : "Vibration\nOFF";
    }
    
    #endregion
}
