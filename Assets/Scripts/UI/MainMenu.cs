using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class MainMenu : MonoBehaviour
{
    private int sceneToContinue;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void Continue()
    {
        sceneToContinue = PlayerPrefs.GetInt("SavedScene");
        if (sceneToContinue != 0)
        {
            SceneManager.LoadSceneAsync(sceneToContinue);
        }
        else
        {
            return;
        }
    }
    public void GoToSettings()
    {
        SceneManager.LoadScene("SettingsMenu");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; //Exit play mode only work when in unity editor
        #endif
    }
}
