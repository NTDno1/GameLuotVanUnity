using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseAndResume : MonoBehaviour
{
    public bool Ispause = false;
    public Button resumeButton;
    public Button pauseButton;
    void Start()
    {
        resumeButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void SetTimeScaleOn()
    {
        Time.timeScale = 1;
    }
    public void SetTimeScaleOff()
    {
        Time.timeScale = 0;
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
        pauseButton.gameObject.SetActive(false);
        resumeButton.gameObject.SetActive(true);
    }
    public void ResumeGame(string sceneName)
    {
        SetTimeScaleOn();
        Ispause = false;
        pauseButton.gameObject.SetActive(true);
        resumeButton.gameObject.SetActive(false);
    }
}
