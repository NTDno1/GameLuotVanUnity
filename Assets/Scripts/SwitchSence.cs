using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchSence : MonoBehaviour
{
    public static bool Ispause = false;
    public static SwitchSence switchSence;
    public Button resumeButton;
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SetTimeScaleOn()
    {
        Time.timeScale = 1;
    }
    public void SetTimeScaleOff()
    {
        Time.timeScale = -1;
    }
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void PauseGame()
    {
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Tên scene hiện tại là: " + sceneName);
        SetTimeScaleOff();
        Ispause = true;
        resumeButton.gameObject.SetActive(true);
    }
    public void ResumeGame(string sceneName)
    {
        SetTimeScaleOff();
        resumeButton.gameObject.SetActive(false);
    }
}